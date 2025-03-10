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
    }

    public class Rover
    {
        private int _xCoordinate = 0;
        private int _yCoordinate = 0;
        private List<string> _directions = new(){"N", "E", "S", "W"};
        private Dictionary<string, (int, int)> _directionsAsCoordinates = new()
        {
            { "N", (0, 1) },
            { "E", (1, 0) },
        };
        private int _facing = 0;
        
        public string Move()
        {
            (int xIncrement, int yIncrement) = _directionsAsCoordinates[_directions[_facing]];
            _xCoordinate = _xCoordinate + xIncrement;
            _yCoordinate = _yCoordinate + yIncrement;
            return _xCoordinate + ":" + _yCoordinate + ":" + _directions[_facing];
        }

        public string TurnLeft()
        {
            --_facing;
            WrapAroundDirections();
            return "0:0:" + _directions[_facing];
        }

        public string TurnRight()
        {
            ++_facing;
            WrapAroundDirections();
            return "0:0:" + _directions[_facing];
        }

        private void WrapAroundDirections()
        {
            _facing = (_facing + 4) % 4;
        }
    }
}