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

        static string accPtrn = Resources.TwitchResources.AccountPattern;

        static DateTime lastMsg;

        static bool keepLogging = true;

        static void Main(string[] args)
        {
            //put what was in the main into a separate method
            //because the entry point of a program can't be async
            MainProgram();
        }

        private static void MainProgram()
        {
            //await SetLogger();
            Initialize();
            Reconnect();

            Timer();
            Console.ReadLine();
            Console.WriteLine("Goodbye");
            keepLogging = false;
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
                Console.WriteLine("Timer started");
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
            });
        }

        private static Task TryReceiveMsgs()
        {
            return Task.Run(() =>
            {
                if (tcpClient.Available > 0 || reader.Peek() >= 0)
                {
                    string msg = reader.ReadLine();

                    //if it's an admin saying something
                }
            });
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

            Console.WriteLine(msg);
        }

        private static void Reconnect()
        {
            int port;
            int.TryParse(Resources.TwitchResources.TwitchIrcPort, out port);

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
        }

        private static void Initialize()
        {
            chatCmdId = Resources.TwitchResources.ChatCmdId;

            chatPrefix = new Regex($"^{accPtrn}!{accPtrn}@{accPtrn}\\.tmi\\.titch\\.tv {chatCmdId} # {accPtrn} $");

            userName = Resources.TwitchResources.UserName;

            channel = GetChat();

            token = Resources.TwitchResources.Token;
            UpdateMsgPrefix();

            sendMsgQueue = new Queue<string>();
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
                string input = Console.ReadLine();
                Console.WriteLine();

                Streamer s = mgr.GetStreamer(input);
                if (s != null)
                {
                    chat = s.User.UserName;
                }
                else
                {
                    User u = mgr.GetUser(input);
                    if (u != null)
                    {
                        Console.WriteLine(Resources.Resources.UnregisteredStreamer);
                    }
                    else
                    {
                        Console.WriteLine(Resources.Resources.UnregisteredUser);
                    }
                    Console.WriteLine();
                }
            }
            return chat;
        }

        //to be able to run it from another project
        public string ReturnPath() => Environment.CurrentDirectory;
    }
}
