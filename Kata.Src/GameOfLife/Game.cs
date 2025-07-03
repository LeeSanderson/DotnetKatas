namespace Kata.Src.GameOfLife;

public class Game(bool[][] universe)
{
    private bool[][] currentUniverse = universe;

    public bool[][] NextGen()
    {
        var nextUniverse = currentUniverse.DeepClone();
        for (var i = 0; i < currentUniverse.Length; i++)
        {
            for (var j = 0; j < currentUniverse[i].Length; j++)
            {
                var livingNeighbours = currentUniverse.GetNeighbours(i, j).Count(isAlive => isAlive);
                nextUniverse[i][j] = IsAlive(currentUniverse[i][j], livingNeighbours);
            }
        }

        currentUniverse = nextUniverse;
        return currentUniverse;
    }

    private static bool IsAlive(bool currentlyAlive, int livingNeighbours)
    {
        if (currentlyAlive)
        {
            if (livingNeighbours < 2) return false; // Underpopulation
            if (livingNeighbours > 3) return false; // Overpopulation
            return true;
        }

        // Else, currentlyDead
        if (livingNeighbours == 3) return true; // Reproduction
        return false;
    }
}