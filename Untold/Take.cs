using System;
using System.Linq;

namespace Untold
{
    [CommandClass]
    public static class TakeCommand
    {
        [Command("TAKE", new string[] { "TAKE" })]
        public static void Take(Game game, CommandContext commandContext)
        {
            if (game.Player.Location.Items.Count == 0)
            {
                Console.WriteLine("You can't see any such thing.");
                return;
            }

            if (game.Player.Inventory.Count == game.World.MaxInventory)
            {
                Console.WriteLine("You can't carry anymore items!");
                return;
            }

            if (game.inputString.Length == 1)
            {
                Console.WriteLine("Take what?");
                return;
            }

            string theItem = game.inputString[1].Trim().ToUpper();
            bool found = false;
            
            foreach (var item in from item in game.Player.Location.Items
                                 where item.Key.ToUpper() == theItem
                                 select item)
            {
                game.Player.Inventory.Add(item.Key, item.Value);
                game.Player.Location.Items.Remove(item.Key);
                Console.WriteLine($"You took the {item.Key}.");
                game.Player.Score += item.Value.Points;
                found = true;
                break;
            }

            if (!found)
            {
                Console.WriteLine("You see no such thing.");
            }
        }
    }
}