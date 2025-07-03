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
        var game = new Game([[false, false, false], [true, true, true], [false, false, false]]);
        var universe = game.NextGen();
        universe[1][1].Should().Be(true);
    }

    [Fact]
    public void LivesIfThreeLivingNeighbours()
    {
        var game = new Game([[false, false, true], [true, true, false], [false, false, true]]);
        var universe = game.NextGen();
        universe[1][1].Should().Be(true);
    }

    [Fact]
    public void DiesIfMoreThanThreeLivingNeighbours()
    {
        var game = new Game([[true, false, true], [false, true, false], [true, false, true]]);
        var universe = game.NextGen();
        universe[1][1].Should().Be(false);
    }

    [Fact]
    public void SpawnIfDeadAndThreeLivingNeighbours()
    {
        bool[][] expectedUniverse = [[false, true, false], [false, true, false], [false, false, false]];
        var game = new Game([[true, false, true], [false, true, false], [false, false, false]]);
        var universe = game.NextGen();
        universe.Should().BeEquivalentTo(expectedUniverse);
    }
}