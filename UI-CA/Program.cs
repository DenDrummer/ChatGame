using System;
using System.Diagnostics;

namespace ChatGame.UI_CA
{
    class Program
    {
        private static bool ShowMenu;
        static void Main(string[] args)
        {
            Console.WriteLine($"{Resources.Resources.Welcome} {Resources.Resources.GameTitle} {Resources.Resources.Version} {Resources.Resources.VersionId}");
            Console.WriteLine(new string('-',
                Resources.Resources.Welcome.Length +
                Resources.Resources.GameTitle.Length +
                Resources.Resources.Version.Length +
                Resources.Resources.VersionId.Length +
                3));
            Console.WriteLine(Resources.Resources.Disclaimer);
            Console.WriteLine();
            ShowMenu = true;
            while (ShowMenu)
            {
                MainMenu();
            }
            Console.WriteLine($"{Resources.Resources.ThanksForUsing} {Resources.Resources.GameTitle}!");
            Console.WriteLine(Resources.Resources.Goodbye);
            Console.WriteLine(Resources.Resources.PressAnyKeyToExit);
            Console.ReadKey();
        }

        private static void MainMenu()
        {
            Console.WriteLine(Resources.Resources.MainMenuText);
            Console.Write($"{Resources.Resources.Choice} => ");
            string command = Console.ReadLine().ToLower();
            Console.WriteLine();
            switch (command.Split(' ')[0])
            {
                case "commands":
                    ListCommands();
                    break;
                case "help":
                    Help(command);
                    break;
                case "logchat":
                    LogChat();
                    break;
                case "quit":
                    ShowMenu = false;
                    break;
                default:
                    InvalidCommand();
                    break;
            }
            Console.WriteLine();
        }

        private static void ListCommands()
        {
            Console.WriteLine($"commands");
            Console.WriteLine($"help");
            Console.WriteLine($"logchat");
            Console.WriteLine($"quit");
        }

        private static void Help(string command)
        {
            string[] parms = command.Split(' ');
            if (parms.Length == 1)
            {
                Console.WriteLine(Resources.Resources.HelpMain);
            }
            else
            {
                Console.Write($"{parms[1]} ");
                switch (parms[1])
                {
                    case "commands":
                        Console.WriteLine(Resources.Resources.HelpCommands);
                        break;
                    case "help":
                        Console.WriteLine(Resources.Resources.HelpHelp);
                        break;
                    case "logchat":
                        Console.WriteLine(Resources.Resources.HelpLogchat);
                        break;
                    case "quit":
                        Console.WriteLine(Resources.Resources.HelpQuit);
                        break;
                    default:
                        InvalidCommand();
                        break;
                }
            }
        }

        private static void LogChat()
        {
            UI_CA_ChatLog.Program p = new UI_CA_ChatLog.Program();
            Process.Start($"{p.ReturnPath()}\\ChatGame.UI-CA-ChatLog.exe");
        }

        private static void InvalidCommand()
        {
            Console.WriteLine(Resources.Resources.InvalidCommand);
        }

        private static void NotImplementedYet()
        {
            Console.WriteLine(Resources.Resources.NotImplementedYet);
        }
    }
}