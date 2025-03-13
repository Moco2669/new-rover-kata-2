using Xunit;

namespace DotnetStarter.Logic.Tests;

public class GridTest
{
    [Fact]
    public void GridHasWidth()
    {
        int xSize = 10;
        int ySize = 7;
        Grid grid = new(xSize, ySize);
        Assert.Equal(xSize, grid.GetWidth());
    }
}

public class Grid
{
    private int _height;
    private int _width;
    
    public Grid(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public int GetWidth()
    {
        return _width;
    }
}