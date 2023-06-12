using System;
using System.IO;
using Test_Turtle_Game.Commands;
using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            IPositionValidator positionValidator = new GridPositionValidator(5, 5);
            Turtle turtle = new Turtle(positionValidator);
            CommandInvoker invoker = new CommandInvoker();
            StreamReader reader = null;

            Console.WriteLine("Welcome to the Turtle Simulator!");
            Console.WriteLine("Commands:");
            Console.WriteLine("PLACE,X,Y,DIRECTION: Place the turtle at a specific position facing a specific direction. E.g., PLACE,1,1,NORTH.");
            Console.WriteLine("MOVE: Move the turtle forward in the direction it's facing.");
            Console.WriteLine("LEFT: Turn the turtle to its left.");
            Console.WriteLine("RIGHT: Turn the turtle to its right.");
            Console.WriteLine("REPORT: Report the current position and direction of the turtle.\n");

            if (args.Length > 0)
            {
                string path = Path.GetFullPath(args[0]);
                
                if (File.Exists(path))
                {
                    try
                    {
                        reader = new StreamReader(path);
                        Console.WriteLine($"Reading commands from file: {path}\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error opening file: {e.Message}\n");
                        Console.WriteLine("Falling back to standard input...\n");
                        reader = new StreamReader(Console.OpenStandardInput());
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter commands:\n");
                reader = new StreamReader(Console.OpenStandardInput());
            }

            try
            {
                CommandsHelper.ReadAndExecuteCommands(reader, invoker, turtle);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading commands: {e.Message}\n");
            }
            finally
            {
                reader.Close();
            }
        }

      
    }
}
