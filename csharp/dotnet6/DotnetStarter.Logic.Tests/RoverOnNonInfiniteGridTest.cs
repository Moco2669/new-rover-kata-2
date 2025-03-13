using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverOnNonInfiniteGridTest
{
    private const int _gridXSize = 10;
    private const int _gridYSize = 7;
    [Fact]
    public void RoverCanBePutOnGrid()
    {
        Rover rover = new();
        rover.PutOnGrid(_gridXSize, _gridYSize);
        Assert.Equal((_gridXSize, _gridYSize), rover.GetGridSize());
    }

    [Fact]
    public void RoverWrapsAroundXCoordinate()
    {
        Rover rover = new();
        rover.PutOnGrid(_gridXSize, _gridYSize);
        string turnRightAndMove11Times = "RMMMMMMMMMMM";
        Assert.Equal("0:0:E", rover.ExecuteInput(turnRightAndMove11Times));
    }

    [Fact]
    public void RoverWrapsAroundYCoordinate()
    {
        Rover rover = new();
        rover.PutOnGrid(_gridXSize, _gridYSize);
        string move8TimesNorth = "MMMMMMMM";
        Assert.Equal("0:0:N", rover.ExecuteInput(move8TimesNorth));
    }

    [Fact]
    public void RoverWrapsAroundGoingSouth()
    {
        Rover rover = new();
        rover.PutOnGrid(_gridXSize, _gridYSize);
        string turnSouthAndMove = "RRM";
        Assert.Equal("0:" + _gridYSize + ":S", rover.ExecuteInput(turnSouthAndMove));
    }
}