namespace Kata.Src.MarsRover;

public class Grid
{
    private readonly Position[] obstaclePositions;

    public Grid(int maxX, int maxY, params Position[] obstaclePositions)
    {
        MaxX = maxX;
        MaxY = maxY;
        this.obstaclePositions = obstaclePositions ?? [];
    }

    internal int MaxX { get; }
    internal int MaxY { get; }

    internal bool ObstacleAt(Position position) => obstaclePositions.Any(p => p == position);
}