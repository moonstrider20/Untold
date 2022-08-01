using System;

namespace Untold
{
    [CommandClass]
    public static class LookCommand
    {
        [Command("LOOK", new string[] { "LOOK", "L" })]
        public static void Look(Game game, CommandContext commandContext)
        {
            Console.WriteLine(game.Player.LocationName);
            Console.WriteLine(game.Player.Location.Description);
        }
    }
}