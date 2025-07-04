namespace Kata.Src.GameOfLife;

public static class ArrayExtensions
{
    public static T[][] DeepClone<T>(this T[][] source) => source.Select(row => row.ToArray()).ToArray();

    public static T[][] Mutate<T>(this T[][] source, Func<T, int, int, T> mutator)
    {
        for (var i = 0; i < source.Length; i++)
        {
            for (var j = 0; j < source[i].Length; j++)
            {
                source[i][j] = mutator(source[i][j], i, j);
            }
        }

        return source;
    }

    private record Offset (int RowOffset, int ColOffset);
    private static readonly Offset[] NeighbourOffsets =
    [
        new(-1, -1), // Top Left
        new(-1, 0),  // Top
        new(-1, 1),  // Top Right
        new(0, -1),  // Left
        new(0, 1),   // Right
        new(1, -1),  // Bottom Left
        new(1, 0),   // Bottom
        new(1, 1)    // Bottom Right
    ];

    public static IEnumerable<T> GetNeighbours<T>(this T[][] source, int row, int col)
    {
        foreach (var neighbourOffset in NeighbourOffsets)
        { 
            var neighbourRow = row + neighbourOffset.RowOffset;
            var neighbourCol = col + neighbourOffset.ColOffset;

            if (neighbourRow >= 0 && neighbourRow < source.Length &&
                neighbourCol >= 0 && neighbourCol < source[neighbourRow].Length)
            {
                yield return source[neighbourRow][neighbourCol];
            }
        }
    }
}