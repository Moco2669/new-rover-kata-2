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

    private int _facing = 0;
    private const int left = -1;
    private const int right = 1;

    public string Move()
    {
        (var xIncrement, var yIncrement) = _directionsAsCoordinates[_directions[_facing]];
        _xCoordinate = _xCoordinate + xIncrement;
        _yCoordinate = _yCoordinate + yIncrement;
        if (_xCoordinate > _gridXSize) _xCoordinate = 0;
        if (_yCoordinate > _gridYSize) _yCoordinate = 0;
        if (_yCoordinate < 0) _yCoordinate = _gridYSize;
        if (_xCoordinate < 0) _xCoordinate = _gridXSize;
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
        string lastCommand = "";
        foreach (char command in commands)
        {
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

    public void PutOnGrid(int xSize, int ySize)
    {
        _gridXSize = xSize;
        _gridYSize = ySize;
    }

    public (int xSize, int ySize) GetGridSize()
    {
        return (_gridXSize, _gridYSize);
    }
}