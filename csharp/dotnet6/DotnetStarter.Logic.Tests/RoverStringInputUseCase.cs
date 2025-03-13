using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverStringInputUseCase
{
    [Fact]
    public void RoverExecutesMoveCommand()
    {
        Rover rover = new();
        Assert.Equal("0:1:N", rover.ExecuteInput("M"));
    }
}