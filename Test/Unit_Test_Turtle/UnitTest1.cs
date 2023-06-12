using Xunit;
using FluentAssertions;
using Test_Turtle_Game;

namespace Unit_Test_Turtle
{
    public class TurtleTests
    {
        [Fact]
        public void Place_Should_Set_X_Y_Direction()
        {
            // Arrange
            var turtle = new Turtle();

            // Act
            turtle.Place(1, 2, Direction.NORTH);

            // Assert
            turtle.Report().Should().Be("1,2,NORTH");
        }

        [Fact]
        public void Move_North_Increments_Y()
        {
            // Arrange
            var turtle = new Turtle();
            turtle.Place(1, 2, Direction.NORTH);

            // Act
            turtle.Move();

            // Assert
            turtle.Report().Should().Be("1,3,NORTH");
        }

        [Fact]
        public void Left_From_North_Should_Face_West()
        {
            // Arrange
            var turtle = new Turtle();
            turtle.Place(1, 2, Direction.NORTH);

            // Act
            turtle.TurnLeft();

            // Assert
            turtle.Report().Should().Be("1,2,WEST");
        }


        [Fact]
        public void Right_From_North_Should_Face_East()
        {
            // Arrange
            var turtle = new Turtle();
            turtle.Place(1, 2, Direction.NORTH);

            // Act
            turtle.TurnRight();

            // Assert
            turtle.Report().Should().Be("1,2,EAST");
        }

        [Fact]
        public void Turtle_Should_Not_Fall_Off_The_Table()
        {
            // Arrange
            var turtle = new Turtle();
            turtle.Place(0, 0, Direction.SOUTH);

            // Act
            turtle.Move();

            // Assert
            turtle.Report().Should().Be("0,0,SOUTH");
        }

    }
}
