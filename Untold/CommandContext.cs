namespace Untold
{
    public struct CommandContext
    {
        public string Commandstring { get; }

        public Command Command { get; }

        public CommandContext(string commandString, Command command)
        {
            Commandstring = commandString;
            Command = command;
        }
    }
}