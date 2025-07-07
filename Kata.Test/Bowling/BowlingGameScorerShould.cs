using FluentAssertions;
using Kata.Src.Bowling;
using Xunit;

namespace Kata.Test.Bowling;

public class BowlingGameScorerShould
{
    [Fact]
    public void ScoreZeroForNoRolls()
    {
        var game = new BowlingGameScorer();
        game.Score.Should().Be(0);
    }

    [Fact]
    public void ScoreZeroForGutterGame()
    {
        var game = new BowlingGameScorer();
        for (var i = 0; i < 20; i++)
        {
            game.Roll(0);
        }
        game.Score.Should().Be(0);
    }

    [Fact]
    public void ScoreOneForSingleRollOfOne()
    {
        var game = new BowlingGameScorer();
        game.Roll(1, 0);
        game.Score.Should().Be(1);
    }
}