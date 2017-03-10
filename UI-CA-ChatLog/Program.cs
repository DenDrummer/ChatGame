using ChatGame.BL;
using ChatGame.BL.Domain;
using System;

namespace ChatGame.UI_CA_ChatLog
{
    public class Program
    {
        private static IGameManager mgr = new GameManager();
        static void Main(string[] args)
        {
            string loggedChat = GetChat();
            Connect(loggedChat);
            Console.WriteLine(Resources.Resources.PressAnyKeyToExit);
            Console.ReadKey();
        }

        private static void Connect(string loggedChat)
        {
            Console.WriteLine(Resources.Resources.NotImplementedYet);
        }

        private static string GetChat()
        {
            string chat = null;
            while (string.IsNullOrEmpty(chat))
            {
                Console.WriteLine(Resources.Resources.AskWhoToLog);
                Console.Write("=> ");
                string input = Console.ReadLine();
                Streamer s = mgr.GetStreamer(input);
                chat = s.User.UserName;
            }
            return chat;
        }

        //to be able to run it from another project
        public string ReturnPath() => Environment.CurrentDirectory;
    }
}
