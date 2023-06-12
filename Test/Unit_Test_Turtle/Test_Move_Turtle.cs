using Xunit;
using FluentAssertions;
using Test_Turtle_Game;
using System.IO;
using System;
using Test_Turtle_Game.Interface;
using Test_Turtle_Game.Commands;

namespace Unit_Test_Turtle
{
    public class Test_Move_Turtle
    {
        private Turtle _turtle;
        private IPositionValidator _positionValidator;

        public Test_Move_Turtle()
        {
            _positionValidator = new GridPositionValidator(5, 5);
            _turtle = new Turtle(_positionValidator);
        }

        [Fact]
        public void TestTurtleInitialState()
        {
            IPositionValidator positionValidator = new GridPositionValidator(5, 5);
            var turtle = new Turtle(positionValidator);

            Assert.False(turtle.IsPlaced);
        }

        [Fact]
        public void Place_Should_Set_X_Y_Direction()
        {
            // Act
            _turtle.Place(1, 2, Direction.NORTH);

            // Assert
            _turtle.ToString().Should().Be("1,2,NORTH");
        }

        [Fact]
        public void Move_North_Increments_Y()
        {
            // Arrange
            _turtle.Place(1, 2, Direction.NORTH);

            // Act
            _turtle.Move();

            // Assert
            _turtle.ToString().Should().Be("1,3,NORTH");
        }

        [Fact]
        public void TestTurtlePlacement()
        {
            IPositionValidator positionValidator = new GridPositionValidator(5, 5);
            var turtle = new Turtle(positionValidator);

            turtle.Place(0, 0, Direction.NORTH);

            Assert.True(turtle.IsPlaced);
        }

        [Fact]
        public void Left_From_North_Should_Face_West()
        {
            // Arrange
            _turtle.Place(1, 2, Direction.NORTH);

            // Act
            _turtle.TurnLeft();

            // Assert
            _turtle.ToString().Should().Be("1,2,WEST");
        }


        [Fact]
        public void Right_From_North_Should_Face_East()
        {
            // Arrange
            _turtle.Place(1, 2, Direction.NORTH);

            // Act
            _turtle.TurnRight();

            // Assert
            _turtle.ToString().Should().Be("1,2,EAST");
        }

        [Fact]
        public void Turtle_Should_Not_Fall_Off_The_Table()
        {
            // Arrange
            _turtle.Place(0, 0, Direction.SOUTH);

            // Act
            _turtle.Move();

            // Assert
            _turtle.ToString().Should().Be("0,0,SOUTH");
        }


        [Fact]
        public void Report_Output_Should_Be_Equal_String()
        {
            // Arrange
            _turtle.Place(0, 0, Direction.SOUTH);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            _turtle.Move();
            _turtle.Report();


            // Assert
            var output = stringWriter.ToString();
            output.Should().Be("0,0,SOUTH\r\n");
        }

        [Fact]
        public void TestReadCommandsFromFile()
        {
            IPositionValidator positionValidator = new GridPositionValidator(5, 5);
            var turtle = new Turtle(positionValidator);
            var invoker = new CommandInvoker();

            using (var reader = new StreamReader("commands.txt"))
            {
                CommandsHelper.ReadAndExecuteCommands(reader, invoker, turtle);
            }

            var position = turtle.GetCurrentPosition();

            Assert.Equal(2, position.X);
            Assert.Equal(2, position.Y);  // The turtle should have moved EAST
            Assert.Equal(Direction.EAST, position.Direction);
        }

    }
}
