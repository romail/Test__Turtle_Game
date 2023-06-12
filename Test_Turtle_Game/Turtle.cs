using System;
using Test_Turtle_Game.Interface;

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
        private readonly IPositionValidator _positionValidator;

        public bool IsPlaced { get => _isPlaced; }

        public Turtle(IPositionValidator positionValidator)
        {
            _isPlaced = false;
            _positionValidator = positionValidator;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (_positionValidator.IsValidPosition(x, y))
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

            if (_positionValidator.IsValidPosition(newX, newY))
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

        public void Report()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{_x},{_y},{_direction}";
        }

       

        public (int X, int Y, Direction Direction) GetCurrentPosition()
        {
            return (_x, _y, _direction);
        }
    }
}
