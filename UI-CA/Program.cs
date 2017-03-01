using System;

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
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"0) {Resources.Resources.Quit}");
            Console.Write($"{Resources.Resources.Choice} => ");
            string choiceString = Console.ReadLine();
            int choice;
            int.TryParse(choiceString, out choice);
            Console.WriteLine();
            switch (choice)
            {
                case 0:
                    ShowMenu = false;
                    break;
                default:
                    InvalidChoice();
                    break;
            }
            Console.WriteLine();
        }

        private static void InvalidChoice()
        {
            Console.WriteLine(Resources.Resources.InvalidChoice);
        }

        private static void NotImplementedYet()
        {
            Console.WriteLine(Resources.Resources.NotImplementedYet);
            Console.WriteLine();
        }
    }
}
