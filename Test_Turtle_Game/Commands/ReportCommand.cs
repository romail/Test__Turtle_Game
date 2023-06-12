using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game.Commands
{
    public class ReportCommand : ICommand
    {
        private readonly Turtle _turtle;

        public ReportCommand(Turtle turtle)
        {
            _turtle = turtle;
        }

        public void Execute()
        {
            _turtle.Report();
        }
    }
}
