using System;

namespace Untold
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Untold.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename;

            Game game = Game.Load(gameFilename);
            Console.WriteLine("Welcome to Untold!");
            game.Run();
            Console.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}