using FluentAssertions;
using Kata.Src.GameOfLife;
using Xunit;

namespace Kata.Test.GameOfLife;

public class GameShould
{
    [Fact]
    public void RemainLifelessIfEmpty()
    {
        bool[][] expectedUniverse = [[false, false, false], [false, false, false], [false, false, false]];
        var game = new Game([[false, false, false], [false, false, false], [false, false, false]]);
        var universe = game.NextGen();
        universe.Should().BeEquivalentTo(expectedUniverse);
    }

    [Fact]
    public void DiesIfZeroLivingNeighbours()
    {
        bool[][] expectedUniverse = [[false, false, false], [false, false, false], [false, false, false]];
        var game = new Game([[false, false, false], [false, true, false], [false, false, false]]);
        var universe = game.NextGen();
        universe.Should().BeEquivalentTo(expectedUniverse);
    }

    [Fact]
    public void DiesIfOneLivingNeighbours()
    {
        bool[][] expectedUniverse = [[false, false, false], [false, false, false], [false, false, false]];
        var game = new Game([[false, false, false], [true, true, false], [false, false, false]]);
        var universe = game.NextGen();
        universe.Should().BeEquivalentTo(expectedUniverse);
    }

    [Fact]
    public void LivesIfTwoLivingNeighbours()
    {
        bool[][] expectedUniverse = [[false, false, false], [false, true, false], [false, false, false]];
        var game = new Game([[false, false, false], [true, true, true], [false, false, false]]);
        var universe = game.NextGen();
        universe.Should().BeEquivalentTo(expectedUniverse);
    }
}