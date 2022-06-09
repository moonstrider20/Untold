using System;

namespace Untold
{
    class Program
    {
        private static string Location => Rooms[locationColumn,locationRow];
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Untold!");

            Commands command = Commands.UNKOWN;
            while (command != Commands.QUIT)
            {
                Console.Write($"{Location}\n> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = Move(command) ? $"You moved {command}." : "The way is shut!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house.";
                        break;
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    default:
                        outputString = "Unknown command.";
                        break;
                };

                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKOWN;

        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch (command)
            {
                case Commands.NORTH when locationRow < Rooms.GetLength(0) - 1:
                    locationRow++;
                    didMove = true;
                    break;
                case Commands.SOUTH when locationRow > 0:
                    locationRow--;
                    didMove = true;
                    break;
                case Commands.EAST when locationColumn < Rooms.GetLength(1) - 1:
                    locationColumn++;
                    didMove = true;
                    break;
                case Commands.WEST when locationColumn > 0:
                    locationColumn--;
                    didMove = true;
                    break;
            }

            return didMove;
        }

        private static readonly string[,] Rooms = {
            {"Rocky Trail", "South of House", "Canyon View" },
            {"Forest", "West of House", "Behind House"},
            {"Dense Woods","North of House","Clearing"}
        };
        private static int locationColumn = 1;
        private static int locationRow = 1;
    }
}
