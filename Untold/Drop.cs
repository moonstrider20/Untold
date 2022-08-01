using System;
using System.Linq;

namespace Untold
{
    [CommandClass]
    public static class DropCommnad
    {
        [Command("DROP", "DROP")]
        public static void Drop(Game game, CommandContext commandContext)
        {
            if (game.Player.Inventory.Count == 0)
            {
                Console.WriteLine("You are empty handed.");
                return;
            }

            if (game.inputString.Length == 1)
            {
                Console.WriteLine("Drop what?");
                return;
            }

            string theItem = game.inputString[1].Trim().ToUpper();
            bool found = false;

            foreach (var item in from item in game.Player.Inventory
                                 where item.Key.ToUpper() == theItem
                                 select item)
            {
                game.Player.Inventory.Remove(item.Key);
                game.Player.Location.Items.Add(item.Key, item.Value);
                Console.WriteLine($"You dropped the {item.Key}.");
                game.Player.Score -= item.Value.Points;
                found = true;
                break;
            }

            if (!found)
            {
                Console.WriteLine("You don't have any such thing.");
            }
        }
    }
}