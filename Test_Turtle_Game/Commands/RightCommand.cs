using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game.Commands
{
    public class RightCommand : ICommand
    {
        private readonly Turtle _turtle;

        public RightCommand(Turtle turtle)
        {
            _turtle = turtle;
        }

        public void Execute()
        {
            _turtle.TurnRight();
        }
    }
}
