using System;

namespace Untold
{
    [CommandClass]
    public static class MovementCommands
    {
        [Command("NORTH", new string[] { "NORTH", "N" })]
        public static void North(Game game, CommandContext commandContext) => Move(game, Directions.North);

        [Command("SOUTH", new string[] { "SOUTH", "S" })]
        public static void South(Game game, CommandContext commandContext) => Move(game, Directions.South);

        [Command("EAST", new string[] { "EAST", "E" })]
        public static void East(Game game, CommandContext commandContext) => Move(game, Directions.East);

        [Command("WEST", new string[] { "WEST", "W" })]
        public static void West(Game game, CommandContext commandContext) => Move(game, Directions.West);

        [Command("NORTHEAST", new string[] { "NORTHEAST", "NE" })]
        public static void Northeast(Game game, CommandContext commandContext) => Move(game, Directions.Northeast);

        [Command("NORTHWEST", new string[] { "NORTHWEST", "NW" })]
        public static void Northwest(Game game, CommandContext commandContext) => Move(game, Directions.Northwest);

        [Command("SOUTHEAST", new string[] { "SOUTHEAST", "SE" })]
        public static void Southeast(Game game, CommandContext commandContext) => Move(game, Directions.Southeast);

        [Command("SOUTHWEST", new string[] { "SOUTHWEST", "SW" })]
        public static void Southwest(Game game, CommandContext commandContext) => Move(game, Directions.Southwest);

        [Command("UP", new string[] { "UP", "U" })]
        public static void Up(Game game, CommandContext commandContext) => Move(game, Directions.Up);

        [Command("DOWN", new string[] { "DOWN", "D" })]
        public static void Down(Game game, CommandContext commandContext) => Move(game, Directions.Down);

        private static void Move(Game game, Directions direction)
        {
            bool playerMoved = game.Player.Move(direction);
            if (playerMoved == false)
            {
                Console.WriteLine("the way is shut!");
            }
        }
    }
}