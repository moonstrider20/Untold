﻿using System;
using System.Collections.Generic;

namespace Untold
{
    internal class Program
    {
        private static Room currentRoom => Rooms[Location.Row, Location.Column];

        static void Main(string[] args)
        {
            InitalizeRoomDescriptions();
            Console.WriteLine("Welcome to Untold!");

            Room previousRoom = null;
            Commands command = Commands.UNKOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(currentRoom);
                
                if (previousRoom != currentRoom)
                {
                    Console.WriteLine(currentRoom.Description);
                    previousRoom = currentRoom;
                }
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine(currentRoom.Description);
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKOWN;
        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction.");

            bool isValidMove = true;

            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;
                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;
                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;
                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;
                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }

        private static readonly Room[,] Rooms = {
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House")},
            { new Room("Dense Woods"),new Room("North of House"), new Room("Clearing")}
        };

        private static void InitalizeRoomDescriptions()
        {
            var roomMap = new Dictionary<string, Room>();
            foreach(Room room in Rooms)
            {
                roomMap.Add(room.Name, room);
            }

            roomMap["Rocky Trail"].Description = "You are on a rocky trail.";                      // Rocky Trail
            roomMap["South of House"].Description = "You are facing the south side of a house.";      // South of House
            roomMap["Canyon View"].Description = "You are at the top of a canyon.";                // Canyon View
            roomMap["Forest"].Description = "This is a forest.";                              // Forest
            roomMap["West of House"].Description = "This is an open field.";                         // West of House
            roomMap["Behind House"].Description = "You are behind a house.";                        // Behind House
            roomMap["Dense Woods"].Description = "This is a dimly lit forest.";                    // Dense Woods
            roomMap["North of House"].Description = "You are facing the north side of a house.";      // North of House
            roomMap["Clearing"].Description = "You are in a clearing.";                         // Clearing
        }

        private static readonly List<Commands> Directions = new List<Commands>
        { 
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };
        
        private static (int Row, int Column) Location = (1,1);
    }
}
