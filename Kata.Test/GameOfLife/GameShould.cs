using FluentAssertions;
using Kata.Src.GameOfLife;
using Xunit;

namespace Kata.Test.GameOfLife;

public class GameShould
{
    [Fact]
    public void RemainLifelessIfEmpty()
    {
        bool[][] universe = [[false, false, false], [false, false, false], [false, false, false]];
        bool[][] expectedUniverse = [[false, false, false], [false, false, false], [false, false, false]];
        var game = new Game(universe);
        game.NextGen();
        universe.Should().BeEquivalentTo(expectedUniverse);
    }

}