using FluentAssertions;
using Kata.Src.Bowling;
using System.Linq;
using Xunit;

namespace Kata.Test.Bowling;

public class BowlingGameScorerShould
{
    private readonly BowlingGameScorer game = new();

    [Fact]
    public void ScoreZeroForNoRolls() => 
        game.Score.Should().Be(0);

    [Fact]
    public void ScoreZeroForGutterGame() =>
        game
            .WithRolls(0.Repeat(20))
            .Score.Should().Be(0);

    [Fact]
    public void ScoreOneForSingleRollOfOne() => 
        game.WithRolls(1).Score.Should().Be(1);

    [Fact]
    public void Score14ForStrikeFollowedByTwoRollsOfOne() => 
        game.WithRolls(10, 1, 1).Score.Should().Be(14);

    [Fact]
    public void Score300ForAPerfectGame() => 
        game
            .WithRolls(10.Repeat(12))
            .Score.Should().Be(300);

    [Fact]
    public void Score16ForSpareFollowedByTwoRollsOfTwo() => 
        game.WithRolls(5, 5, 2, 2).Score.Should().Be(16);
}

public static class BowlingGameScorerExtensions
{
    public static BowlingGameScorer WithRolls(this BowlingGameScorer scorer, params int[] rolls)
    {
        foreach (var roll in rolls)
        {
            scorer.Roll(roll);
        }
        return scorer;
    }

    public static int[] Repeat(this int n, int count) => 
        Enumerable.Repeat(n, count).ToArray();
}