namespace Kata.Src.GameOfLife;

public static class ArrayExtensions
{
    public static T[][] DeepClone<T>(this T[][] source) => source.Select(row => row.ToArray()).ToArray();

    public static T[][] Mutate<T>(this T[][] source, Func<T, int, int, T> mutator)
    {
        for (int i = 0; i < source.Length; i++)
        {
            for (int j = 0; j < source[i].Length; j++)
            {
                source[i][j] = mutator(source[i][j], i, j);
            }
        }

        return source;
    }

    public static IEnumerable<T> GetNeighbours<T>(this T[][] source, int row, int col)
    {
        bool rowAboveAvailable = row > 0;
        bool rowBelowAvailable = row < source.Length - 1;
        bool colLeftAvailable = col > 0;
        bool colRightAvailable = col < source[row].Length - 1;

        if (rowAboveAvailable)
        {
            if (colLeftAvailable)
                yield return source[row - 1][col - 1]; // Top Left
            yield return source[row - 1][col]; // Top
            if (colRightAvailable)
                yield return source[row - 1][col + 1]; // Top Right
        }

        if (colLeftAvailable)
            yield return source[row][col - 1]; // Left
        if (colRightAvailable)
            yield return source[row][col + 1]; // Right

        if (rowBelowAvailable)
        {
            if (colLeftAvailable)
                yield return source[row + 1][col - 1]; // Bottom Left
            yield return source[row + 1][col]; // Bottom
            if (colRightAvailable)
                yield return source[row + 1][col + 1]; // Bottom Right
        }
    }
}