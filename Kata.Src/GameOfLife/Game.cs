using Microsoft.VisualBasic;

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
                nextUniverse[i][j] = IsAlive(currentUniverse[i][j], currentUniverse.GetNeighbours(i, j));
            }
        }

        currentUniverse = nextUniverse;
        return currentUniverse;
    }

    private bool IsAlive(bool currentlyAlive, IEnumerable<bool> neighbours)
    {
        var livingNeighbours = neighbours.Count(isAlive => isAlive);
        if (currentlyAlive)
        {
            if (livingNeighbours < 2 || livingNeighbours > 3) return false;
            return true;
        }

        return false;
    }
}