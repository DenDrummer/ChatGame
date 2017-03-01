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
            Console.WriteLine(Resources.Resources.ThanksForUsing);
            Console.WriteLine(Resources.Resources.Goodbye);
            Console.WriteLine(Resources.Resources.PressAnyKeyToExit);
            Console.ReadKey();
        }

        private static void MainMenu()
        {
            Console.WriteLine(Resources.Resources.NotImplementedYet);
            Console.WriteLine();
            ShowMenu = false;
        }
    }
}
