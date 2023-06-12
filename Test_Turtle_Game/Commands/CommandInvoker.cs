using System.Collections.Generic;
using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game.Commands
{
    public class CommandInvoker
    {
        private readonly List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }
}
