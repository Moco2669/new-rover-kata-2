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
    }

    public class Rover
    {
        public string Move()
        {
            return "0:1:N";
        }
    }
}