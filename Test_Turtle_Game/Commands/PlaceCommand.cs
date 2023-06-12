using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly Turtle _turtle;
        private readonly int _x;
        private readonly int _y;
        private readonly Direction _direction;

        public PlaceCommand(Turtle turtle, int x, int y, Direction direction)
        {
            _direction = direction;
            _turtle = turtle;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _turtle.Place(_x, _y, _direction);
        }
    }
}
