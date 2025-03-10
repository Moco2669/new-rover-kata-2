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
    }

    public class Rover
    {
        private int _yCoordinate = 0;
        private List<string> _directions = new(){"N", "E", "S", "W"};
        private int _facing = 0;
        
        public string Move()
        {
            ++_yCoordinate;
            return "0:" + _yCoordinate + ":" + _directions[_facing];
        }

        public string TurnLeft()
        {
            --_facing;
            WrapAroundDirections();
            return "0:0:" + _directions[_facing];
        }

        private void WrapAroundDirections()
        {
            _facing = (_facing + 4) % 4;
        }
    }
}