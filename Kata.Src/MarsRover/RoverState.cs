namespace Kata.Src.MarsRover;

public record RoverState(Position Position, Facing Facing, bool HitObstacle = false)
{
    public override string ToString()
    {
        return $"{(HitObstacle ? "O:" : string.Empty)}{X}:{Y}:{Facing.CompassPoint()}";
    }

    public int X => Position.X;
    public int Y => Position.Y;

    public RoverState RotateLeft() => this with { Facing = Facing.RotateLeft() };

    public RoverState RotateRight() => this with { Facing = Facing.RotateRight() };

    public RoverState MoveOn(Grid grid)
    {
        var newX = ApplyMoveDelta(X, Facing.XDelta(), grid.MaxX);
        var newY = ApplyMoveDelta(Y, Facing.YDelta(), grid.MaxY);
        var newPosition = new Position(newX, newY);
        return grid.ObstacleAt(newPosition) 
            ? this with { HitObstacle = true } 
            : this with { Position = newPosition };
    }

    private static int ApplyMoveDelta(int current, int change, int max) => (current + change + max) % max;
}
