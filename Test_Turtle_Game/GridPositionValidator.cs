using Test_Turtle_Game.Interface;

namespace Test_Turtle_Game
{
    public class GridPositionValidator : IPositionValidator
    {
        private readonly int maxX;
        private readonly int maxY;

        public GridPositionValidator(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= maxX && y >= 0 && y <= maxY;
        }
    }
}
