using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverOnNonInfiniteGridTest
{
    [Fact]
    public void RoverCanBePutOnGrid()
    {
        int xSize = 10;
        int ySize = 7;
        Rover rover = new();
        rover.PutOnGrid(xSize, ySize);
        Assert.Equal((xSize, ySize), rover.GetGridSize());
    }

    [Fact]
    public void GridWrapsAroundXCoordinate()
    {
        int xSize = 10;
        int ySize = 7;
        Rover rover = new();
        rover.PutOnGrid(xSize, ySize);
        Assert.Equal("0:0:E", rover.ExecuteInput("RMMMMMMMMMMM"));
    }
}