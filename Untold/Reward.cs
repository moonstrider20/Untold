using System;


namespace Untold
{
    [CommandClass]
    public static class RewardCommnad
    {
        [Command("REWARD", new string[] { "REWARD" })]
        public static void Reward(Game game, CommandContext commandContext)
        {
            game.Player.Score++;
            Console.WriteLine("Rewarding yourself are you?");
        }
    }
}