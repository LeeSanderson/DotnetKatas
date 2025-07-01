namespace Kata.Src.MarsRover;

public class Rover
{
    private readonly Dictionary<char, Func<RoverState, RoverState>> commandMap;
    private RoverState roverState = new(new Position(0, 0), Facing.North);

    public Rover(Grid? grid = null)
    {
        var currentGrid = grid ?? new Grid(10, 10);
        commandMap = new()
        {
            { 'L', state => state.RotateLeft() },
            { 'R', state => state.RotateRight() },
            { 'M', state => state.MoveOn(currentGrid) }
        };
    }

    public string Execute(string commands)
    {
        foreach (var command in commands)
        {
            roverState = commandMap[command](roverState);
            if (roverState.HitObstacle)
                break;
        }

        return  roverState.ToString();
    }
}