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
        public void RoverTurnsLeftOnce()
        {
            Rover rover = new();
            Assert.Equal("0:0:W", rover.TurnLeft());
        }

        [Fact]
        public void RoverTurnsLeftTwice()
        {
            Rover rover = new();
            rover.TurnLeft();
            Assert.Equal("0:0:S", rover.TurnLeft());
        }

        [Fact]
        public void RoverTurnsRightOnce()
        {
            Rover rover = new();
            Assert.Equal("0:0:E", rover.TurnRight());
        }

        [Fact]
        public void RoverTurnsAroundRightSide()
        {
            Rover rover = new();
            rover.TurnRight();
            rover.TurnRight();
            rover.TurnRight();
            Assert.Equal("0:0:N", rover.TurnRight());
        }

        [Fact]
        public void RoverMovesEast()
        {
            Rover rover = new();
            rover.TurnRight();
            Assert.Equal("1:0:E", rover.Move());
        }

        [Fact]
        public void RoverMovesSouth()
        {
            Rover rover = new();
            rover.Move();
            rover.Move();
            rover.TurnRight();
            rover.TurnRight();
            Assert.Equal("0:1:S", rover.Move());
        }

        [Fact]
        public void RoverMovesWest()
        {
            Rover rover = new();
            rover.TurnLeft();
            Assert.Equal("-1:0:W", rover.Move());
        }
    }
}