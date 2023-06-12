using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Turtle turtle;

        public MoveCommand(Turtle turtle)
        {
            this.turtle = turtle;
        }

        public void Execute()
        {
            turtle.Move();
        }
    }
}
