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

    [Fact]
    public void RoverExecutesTurnLeftCommand()
    {
        Rover rover = new();
        Assert.Equal("0:0:W", rover.ExecuteInput("L"));
    }

    [Fact]
    public void RoverExecutesTurnRightCommand()
    {
        Rover rover = new();
        Assert.Equal("0:0:E", rover.ExecuteInput("R"));
    }

    [Fact]
    public void RoverExecutesMultipleCommands()
    {
        Rover rover = new();
        Assert.Equal("2:1:W", rover.ExecuteInput("RMMLML"));
    }
}