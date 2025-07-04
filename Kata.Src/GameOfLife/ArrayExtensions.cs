namespace Kata.Src.GameOfLife;

public static class ArrayExtensions
{
    public static T[][] DeepClone<T>(this T[][] source) => source.Select(row => row.ToArray()).ToArray();

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

            if (source.AreRowColIndicesValid(neighbourRow, neighbourCol))
            {
                yield return source[neighbourRow][neighbourCol];
            }
        }
    }

    private static bool AreRowColIndicesValid<T>(this T[][] source, int row, int col)
    {
        return row >= 0 && row < source.Length &&
               col >= 0 && col < source[row].Length;
    }
}