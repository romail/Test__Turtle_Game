using System;
using System.IO;
using Test_Turtle_Game.Commands;
using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game
{
    public static class CommandsHelper
    {
        public static void ReadAndExecuteCommands(TextReader reader, CommandInvoker invoker, Turtle turtle)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(' ', ',');

                ICommand command = null;

                if (parts[0] == "PLACE" && parts.Length == 4)
                {
                    try
                    {
                        int x = Convert.ToInt32(parts[1]);
                        int y = Convert.ToInt32(parts[2]);
                        Direction direction = (Direction)Enum.Parse(typeof(Direction), parts[3]);
                        command = new PlaceCommand(turtle, x, y, direction);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid PLACE command. Please check your parameters.");
                    }
                }
                else if (parts[0] == "MOVE")
                {
                    command = new MoveCommand(turtle);
                }
                else if (parts[0] == "LEFT")
                {
                    command = new LeftCommand(turtle);
                }
                else if (parts[0] == "RIGHT")
                {
                    command = new RightCommand(turtle);
                }
                else if (parts[0] == "REPORT")
                {
                    command = new ReportCommand(turtle);
                }
                else
                {
                    Console.WriteLine($"Invalid command: {parts[0]}");
                }

                if (command != null)
                {
                    command.Execute();
                }
            }
        }
    }
}
