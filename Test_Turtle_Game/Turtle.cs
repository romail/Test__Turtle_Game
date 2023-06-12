using System;

namespace Test_Turtle_Game
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class Turtle
    {
        private int _x;
        private int _y;
        private Direction _direction;
        private bool _isPlaced;

        public Turtle()
        {
            _isPlaced = false;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (IsValidPosition(x, y))
            {
                _x = x;
                _y = y;
                _direction = direction;
                _isPlaced = true;
            }
        }

        public void Move()
        {
            if (!_isPlaced)
                return;

            int newX = _x;
            int newY = _y;

            switch (_direction)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            if (IsValidPosition(newX, newY))
            {
                _x = newX;
                _y = newY;
            }
        }

        public void TurnLeft()
        {
            if (!_isPlaced)
                return;

            _direction = (Direction)(((int)_direction + 3) % 4);
        }

        public void TurnRight()
        {
            if (!_isPlaced)
                return;

            _direction = (Direction)(((int)_direction + 1) % 4);
        }

        public string Report()
        {
            if (!_isPlaced)
                return null;

            string result = $"{_x},{_y},{_direction}";

            Console.WriteLine(result);

            return result;
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= 5 && y >= 0 && y <= 5;
        }
    }

}
