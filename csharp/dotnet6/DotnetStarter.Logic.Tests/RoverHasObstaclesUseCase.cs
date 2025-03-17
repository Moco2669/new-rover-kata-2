using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverHasObstaclesUseCase
{
    [Fact]
    public void RoverReportsObstacle()
    {
        int obstacleXPos = 2;
        int obstacleYPos = 3;
        Rover rover = new();
        rover.AddObstacle(obstacleXPos, obstacleYPos);
        string stepsToObstacle = "RMMLMM";
        Assert.Equal("O:2:2:N", rover.ExecuteInput(stepsToObstacle));
    }

    [Fact]
    public void RoverStopsAtObstacle()
    {
        int obstacleXPos = 2;
        int obstacleYPos = 3;
        Rover rover = new();
        rover.AddObstacle(obstacleXPos, obstacleYPos);
        string forceablyTryToMovePastObstacle = "RMMLMMMMMMM";
        Assert.Equal("O:2:2:N", rover.ExecuteInput(forceablyTryToMovePastObstacle));
    }
}