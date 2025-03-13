using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Rover
{
    private int _xCoordinate = 0;
    private int _yCoordinate = 0;
    private List<string> _directions = new() { "N", "E", "S", "W" };

    private Dictionary<string, (int, int)> _directionsAsCoordinates = new()
    {
        { "N", (0, 1) },
        { "E", (1, 0) },
        { "S", (0, -1) },
        { "W", (-1, 0) }
    };

    private int _facing = 0;
    private const int left = -1;
    private const int right = 1;

    public string Move()
    {
        (var xIncrement, var yIncrement) = _directionsAsCoordinates[_directions[_facing]];
        _xCoordinate = _xCoordinate + xIncrement;
        _yCoordinate = _yCoordinate + yIncrement;
        return WriteReport();
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
        return _xCoordinate + ":" + _yCoordinate + ":" + _directions[_facing];
    }

    private void WrapAroundDirections()
    {
        _facing = (_facing + 4) % 4;
    }

    public string ExecuteInput(string commands)
    {
        switch (commands)
        {
            case "M":
                return Move();
            case "L":
                return TurnLeft();
            case "R":
                return TurnRight();
            default:
                return Move();
        }
    }
}