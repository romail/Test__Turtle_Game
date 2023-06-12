using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game.Commands
{
    public class LeftCommand : ICommand
    {
        private readonly Turtle _turtle;

        public LeftCommand(Turtle turtle)
        {
            this._turtle = turtle;
        }

        public void Execute()
        {
            _turtle.TurnLeft();
        }
    }
}
