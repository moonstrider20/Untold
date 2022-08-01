using System;

namespace Untold
{
    [CommandClass]
    public static class LookCommand
    {
        [Command("LOOK", new string[] { "LOOK", "L" })]
        public static void Look(Game game, CommandContext commandContext)
        {
            Console.WriteLine($"{game.Player.LocationName}\n{game.Player.Location.Description}");

            if (game.Player.Location.Items.Count != 0)
            {
                foreach (var item in game.Player.Location.Items)
                {
                    Console.WriteLine($"There is a {item.Key}");
                }
            }
        }
    }
}