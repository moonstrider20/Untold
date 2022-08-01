using System;
using Untold;

string[] responses = new string[]
{
    "Good day.",
    "Nice weather we've been having lately.",
    "Nice to see you."
};

var command = new Command("HELLO", new string[] { "HELLO", "HI", "HOWDY" },
    (game, commandContext) =>
    {
        string selectResponse = responses[Game.Random.Next(responses.Length)];
        Console.WriteLine(selectResponse);
    });

Game.Instance.CommandManager.AddCommand(command);