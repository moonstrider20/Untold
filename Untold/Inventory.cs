using System;

namespace Untold
{
    [CommandClass]
    public static class InventoryCommand
    {
        [Command("INVENTORY", new string[] {"INVENTROY", "I"})]
        public static void Inventory(Game game, CommandContext commandContext)
        {
            if (game.Player.Inventory.Count == 0)
            {
                Console.WriteLine("You are empty handed.");
                return;
            }

            Console.WriteLine("You are carrying: ");
            foreach (var item in game.Player.Inventory)
            {
                Console.WriteLine(item.Value.Description);
            }
        }
    }
}