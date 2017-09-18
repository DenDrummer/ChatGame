using ChatGame.BL;
using ChatGame.BL.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ChatGame.UI_CA_ChatLog
{
    public class Program
    {
        private static IGameManager mgr = new GameManager();

        static Queue<string> sendMsgQueue;

        //static StreamWriter logger;

        static TcpClient tcpClient;
        static StreamReader reader;
        static StreamWriter writer;

        static string userName, token, channel, msgPrefix, chatCmdId;
        private static Regex chatPrefix;

        static string accPtrn;

        static DateTime lastMsg;

        static bool keepLogging = true;

        static void Main(string[] args)
        {
            try
            {
                //put what was in the main into a separate method
                //because the entry point of a program can't be async
                MainProgram();
            }
            catch (Exception e)
            {
                WriteError($"{e.Message}: {Resources.Resources.ResourceManager.GetString(e.Message)}");
            }
            Console.ReadLine();
            keepLogging = false;
            Console.WriteLine($"{Resources.Resources.ThanksForUsing} {Resources.Resources.GameTitle}!");
            Console.WriteLine(Resources.Resources.Goodbye);
            Console.WriteLine(Resources.Resources.PressAnyKeyToExit);
            Console.ReadKey();
        }

        private /*async*/ static void MainProgram() //uncomment async once Logger works
        {
            //await SetLogger();
            Initialize();
            Reconnect();

            Timer();
        }

        //this is not working yet, but is not a priority
        //private static Task SetLogger()
        //{
        //    return Task.Run(() =>
        //    {
        //        //set a logger so everything is being logged into a separate file
        //        DateTime dt = DateTime.Now;
        //        logger = new StreamWriter($"chatlog{dt.Year}{dt.Month}{dt.Day}{dt.Hour}{dt.Minute}{dt.Second}.txt");
        //        Console.SetOut(logger);
        //    });
        //}

        private static Task Timer()
        {
            return Task.Run(async () =>
            {
                Console.WriteLine(Resources.Resources.TimerStarted);
                while (keepLogging)
                {
                    if (!tcpClient.Connected)
                    {
                        Reconnect();
                    }

                    Task send = TrySendMsgs();

                    Task receive = TryReceiveMsgs();

                    await Task.WhenAll(send, receive);

                    await Task.Run(() => Thread.Sleep(250));
                }
                Console.WriteLine(Resources.Resources.TimerStopped);
            });
        }

        private static Task TryReceiveMsgs()
        {
            return Task.Run(() =>
            {
                if (tcpClient.Available > 0 || reader.Peek() >= 0)
                {
                    string msg = reader.ReadLine();

                    //if it's a ChatGame admin saying something (aka admin commands (see that supertruck game))
                    if (new Regex(Resources.TwitchResources.AdminMsgPattern).IsMatch(msg.Split(':')[1]))
                    {
                        //check if it's a command

                    }
                    //string filteredMsg = FilterMsg(msg);
                    UpdateChatLog(msg);
                }
            });
        }

        private static string FilterMsg(string msg)
        {
            //if it's a regular chat message filter out redundant information
            if (chatPrefix.IsMatch(msg.Split(':')[1]))
            {
                string chat = new Regex(accPtrn).Match(msg.Split('#')[1]).ToString();
                string user = new Regex(accPtrn).Match(msg).ToString();
                string newMsg = msg.Substring(msg.IndexOf(':', 1) + 1).Trim();
                return $"(#{chat}) {user}: {newMsg}";
            }
            //else show the entire unfiltered msg
            else
            {
                return msg;
            }
        }

        private static Task TrySendMsgs()
        {
            return Task.Run(() =>
            {
                if (DateTime.Now - lastMsg > TimeSpan.FromMilliseconds(2000))
                {
                    if (sendMsgQueue.Count > 0)
                    {
                        sendMsg(sendMsgQueue.Dequeue());
                    }
                }
            });
        }

        private static void sendMsg(string msg)
        {
            writer.WriteLine($"{msgPrefix}{msg}");
            UpdateChatLog($"{msgPrefix}{msg}");
        }

        private static void UpdateChatLog(string msg)
        {
            //if it's a regular chat message, only show the chat and speaker in the following format:
            //(#chat) user: message
            if (chatPrefix.IsMatch(msg.Split(':')[1]))
            {
                string chat = new Regex(accPtrn).Match(msg.Split('#')[1]).ToString();
                string user = new Regex(accPtrn).Match(msg).ToString();
                string newMsg = msg.Substring(msg.IndexOf(':', 1) + 1).Trim();
                msg = $"(#{chat}) {user}: {newMsg}";
            }
            msg = FilterMsg(msg);

            Console.WriteLine(msg);
        }

        private static void Initialize()
        {
            chatCmdId = Resources.TwitchResources.ChatCmdId;
            accPtrn = Resources.TwitchResources.AccountPattern;

            chatPrefix = new Regex($"^{accPtrn}!{accPtrn}@{accPtrn}\\.tmi\\.titch\\.tv {chatCmdId} # {accPtrn} $");

            userName = Resources.TwitchResources.UserName;

            channel = GetChat();

            token = Resources.TwitchResources.Token;
            UpdateMsgPrefix();

            sendMsgQueue = new Queue<string>();
        }

        private static void Reconnect()
        {
            int port;
            int.TryParse(Resources.TwitchResources.TwitchIrcPort, out port);
            try
            {
                tcpClient = new TcpClient(Resources.TwitchResources.TwitchIrc, port);
                reader = new StreamReader(tcpClient.GetStream());
                writer = new StreamWriter(tcpClient.GetStream());
                writer.AutoFlush = true;

                //log in
                string nl = Environment.NewLine;
                writer.WriteLine($"PASS {token}{nl}" +
                    $"NICK {userName}{nl}" +
                    $"USER {userName} 8 * :{userName}");

                //show users and moderators in chatlog
                writer.WriteLine("CAP REQ :twitch.tv/membership");

                //join chat
                writer.WriteLine($"JOIN #{channel}");
                UpdateMsgPrefix();
                lastMsg = DateTime.Now;
                Console.WriteLine(Resources.Resources.Connected);
            }
            catch (SocketException)
            {
                Console.WriteLine(Resources.Resources.FailedTcpClient);
            }
        }

        private static void UpdateMsgPrefix()
        {
            msgPrefix = $":{userName}!{userName}@{userName}.tmi.twitch.tv {chatCmdId} #{channel}";
        }

        private static string GetChat()
        {
            string chat = null;
            while (string.IsNullOrEmpty(chat))
            {
                Console.WriteLine(Resources.Resources.AskWhoToLog);
                Console.Write("=> ");
                string input = Console.ReadLine().Split(' ')[0].ToLower();
                Console.WriteLine();

                //if the user exists
                User u = mgr.GetUser(input);
                Streamer s = mgr.GetStreamer(input);
                if (u == null)
                {
                    //tell the user this and ask if they want to add them to the list of users
                    WriteError(Resources.Resources.UnregisteredUser);
                    Console.WriteLine();
                    //ask if they want to register this person as a streamer
                    u = AskRegisterUser(input);
                    //if they registered the user
                    if (u != null)
                    {
                        //ask if they want to also register them as livestreamer
                        Console.WriteLine($"{Resources.Resources.AskRegisterStreamerAlso} {Resources.Resources.YesOrNo} {u.UserName}");
                        s = AskRegisterStreamer(u);
                    }
                }
                //if they're a user but not registered as a livestreamer yet
                else if (s == null)
                {
                    //ask if they want to register them as livestreamer
                    Console.WriteLine($"{Resources.Resources.AskRegisterStreamer} {Resources.Resources.YesOrNo} {u.UserName}");
                    s = AskRegisterStreamer(u);
                }

                //if the streamer does exist already or has been added
                if (s != null)
                {
                    //set the chat to this user;
                    chat = s.User.UserName;
                }
            }
            return chat;
        }

        private static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        private static User AskRegisterUser(string userName)
        {
            bool validResponse = false;
            User u = null;
            while (!validResponse)
            {
                Console.WriteLine($"{Resources.Resources.AskRegisterUser} {Resources.Resources.YesOrNo} {userName}");
                string input = Console.ReadLine().ToLower().Substring(0, 1);
                Console.WriteLine();
                if (input.Equals(Resources.Resources.Yes.ToLower().Substring(0, 1)))
                {
                    validResponse = true;
                    u = mgr.AddUser(userName);
                }
                else if (input.Equals(Resources.Resources.No.ToLower().Substring(0, 1)))
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine(Resources.Resources.InvalidResponse);
                }
            }
            return u;
        }

        private static Streamer AskRegisterStreamer(User u)
        {
            bool validResponse = false;
            Streamer s = null;
            while (!validResponse)
            {
                string input = Console.ReadLine().ToLower().Substring(0, 1);
                Console.WriteLine();
                if (input.Equals(Resources.Resources.Yes.ToLower().Substring(0, 1)))
                {
                    validResponse = true;
                    s = mgr.AddStreamer(u.UserName);
                }
                else if (input.Equals(Resources.Resources.No.ToLower().Substring(0, 1)))
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine(Resources.Resources.InvalidResponse);
                }
            }
            return s;
        }

        //required to be able to run it from another project
        public string ReturnPath() => Environment.CurrentDirectory;
    }
}
