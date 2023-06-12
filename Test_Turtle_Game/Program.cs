using System;
using System.Collections.Generic;
using Test_Turtle_Game.Commands;

namespace Test_Turtle_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Turtle turtle = new Turtle();

            var strategies = new Dictionary<string, Action<string>>
            {
                {
                    "PLACE", (commandLine) =>
                    {
                        var parts = commandLine.Split(' ', ',');
                        if (parts.Length == 4 && Enum.TryParse(parts[3], out Direction direction) &&
                            int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
                        {
                            new PlaceCommand(turtle, x, y, direction).Execute();
                        }
                    }
                },
                { "MOVE", (commandLine) => new MoveCommand(turtle).Execute() },
                { "LEFT", (commandLine) => new LeftCommand(turtle).Execute() },
                { "RIGHT", (commandLine) => new RightCommand(turtle).Execute() },
                { "REPORT", (commandLine) => new ReportCommand(turtle).Execute() },
            };

            Console.WriteLine("Enter command:");

            string command;
            while ((command = Console.ReadLine()) != null)
            {
                var parts = command.Split(' ', ',');
                if (strategies.ContainsKey(parts[0]))
                {
                    strategies[parts[0]].Invoke(command);
                }
            }
        }
    }

}
