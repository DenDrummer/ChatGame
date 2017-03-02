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
        }

        private static string GetChat()
        {
            string chat = null;
            while (!string.IsNullOrEmpty(chat))
            {
                Console.WriteLine(Resources.Resources.AskWhoToLog);
                Console.Write("=> ");
                string input = Console.ReadLine();
                //the line below will give an error as it has not been implemented yet in the GameManager class
                Streamer s = mgr.GetStreamer(input);
                chat = s.User.UserName;
            }
            return chat;
        }
    }
}
