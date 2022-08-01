using System;

namespace Untold
{
   [CommandClass]
   public static class ScoreCommand
    {
        [Command("SCORE", new string[] { "SCORE" })]
        public static void Score(Game game, CommandContext commandContext) => Console.WriteLine($"Your score would be {game.Player.Score} in {game.Player.Moves} moves(s).");
    }
}