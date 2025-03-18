using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Rover
{
    private int _xCoordinate = 0;
    private int _yCoordinate = 0;
    private List<string> _directions = new() { "N", "E", "S", "W" };

    private int _gridXSize = int.MaxValue;
    private int _gridYSize = int.MaxValue;

    private Dictionary<string, (int, int)> _directionsAsCoordinates = new()
    {
        { "N", (0, 1) },
        { "E", (1, 0) },
        { "S", (0, -1) },
        { "W", (-1, 0) }
    };

    private Dictionary<int, List<int>> _obstacles = new();

    private int _facing = 0;
    private const int left = -1;
    private const int right = 1;

    public string Move()
    {
        (int nextX, int nextY) = CalculateNextPoint();
        (_xCoordinate, _yCoordinate) = (nextX, nextY);
        return WriteReport();
    }

    private (int nextX, int nextY) CalculateNextPoint()
    {
        (var xIncrement, var yIncrement) = _directionsAsCoordinates[_directions[_facing]];
        int nextX = _xCoordinate + xIncrement;
        int nextY = _yCoordinate + yIncrement;
        if (nextX > _gridXSize) nextX = 0;
        if (nextY > _gridYSize) nextY = 0;
        if (nextY< 0) nextY = _gridYSize;
        if (nextX < 0) nextX = _gridXSize;
        return (nextX, nextY);
    }

    public string TurnLeft()
    {
        Turn(left);
        return WriteReport();
    }

    public string TurnRight()
    {
        Turn(right);
        return WriteReport();
    }

    private void Turn(int direction)
    {
        _facing = _facing + direction;
        WrapAroundDirections();
    }

    private string WriteReport()
    {
        return (FacingObstacle() ? "O:" : "") + _xCoordinate + ":" + _yCoordinate + ":" + _directions[_facing];
    }

    private void WrapAroundDirections()
    {
        _facing = (_facing + 4) % 4;
    }

    public string ExecuteInput(string commands)
    {
        string lastCommand = WriteReport();
        foreach (char command in commands)
        {
            if (FacingObstacle())
            {
                return lastCommand;
            }
            switch (command)
            {
                case 'M':
                    lastCommand = Move();
                    break;
                case 'L':
                    lastCommand = TurnLeft();
                    break;
                case 'R':
                    lastCommand = TurnRight();
                    break;
            }
        }
        return lastCommand;
    }

    private bool FacingObstacle()
    {
        (int nextX, int nextY) = CalculateNextPoint();
        if (_obstacles.ContainsKey(nextX))
        {
            return _obstacles[nextX].Contains(nextY);
        }
        return false;
    }

    public void PutOnGrid(int xSize, int ySize)
    {
        _gridXSize = xSize;
        _gridYSize = ySize;
    }

    public (int xSize, int ySize) GetGridSize()
    {
        return (_gridXSize, _gridYSize);
    }

    public void AddObstacle(int obstacleXPos, int obstacleYPos)
    {
        if (!_obstacles.ContainsKey(obstacleYPos))
        {
            _obstacles[obstacleXPos] = new List<int>();
        }

        if (!_obstacles[obstacleXPos].Contains(obstacleYPos))
        {
            _obstacles[obstacleXPos].Add(obstacleYPos);
        }
    }
}