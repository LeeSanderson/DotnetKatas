namespace Kata.Src.MarsRover;

public class Grid(int maxX, int maxY, params Position[] obstaclePositions)
{
    private readonly Position[] obstaclePositions = obstaclePositions ?? [];

    internal int MaxX { get; } = maxX;
    internal int MaxY { get; } = maxY;

    internal bool ObstacleAt(Position position) => obstaclePositions.Any(p => p == position);
}