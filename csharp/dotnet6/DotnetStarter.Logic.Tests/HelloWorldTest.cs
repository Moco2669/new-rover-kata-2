using System.Collections.Generic;
using Xunit;

namespace DotnetStarter.Logic.Tests
{
    public class HelloWorldTest
    {
        [Fact]
        public void Hello_ReturnsWorld() => Assert.Equal("World!", HelloWorld.Hello());

        [Fact]
        public void RoverMovesOnePoint()
        {
            Rover rover = new();
            Assert.Equal("0:1:N", rover.Move());
        }

        [Fact]
        public void RoverMovesTwoPoints()
        {
            Rover rover = new();
            rover.Move();
            Assert.Equal("0:2:N", rover.Move());
        }

        [Fact]
        public void RoverTurnsLeft()
        {
            Rover rover = new();
            Assert.Equal("0:0:W", rover.TurnLeft());
        }
    }

    public class Rover
    {
        private int yCoordinate = 0;
        public string Move()
        {
            ++yCoordinate;
            return "0:"+yCoordinate+":N";
        }

        public string TurnLeft()
        {
            return "0:0:W";
        }
    }
}