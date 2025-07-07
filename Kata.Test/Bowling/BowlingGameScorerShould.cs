using FluentAssertions;
using Kata.Src.Bowling;
using Xunit;

namespace Kata.Test.Bowling;

public class BowlingGameScorerShould
{
    private readonly BowlingGameScorer game = new();

    [Fact]
    public void ScoreZeroForNoRolls()
    {
        game.Score.Should().Be(0);
    }

    [Fact]
    public void ScoreZeroForGutterGame()
    {
        for (var i = 0; i < 20; i++)
        {
            game.Roll(0);
        }
        game.Score.Should().Be(0);
    }

    [Fact]
    public void ScoreOneForSingleRollOfOne()
    {
        game.Roll(1, 0);
        game.Score.Should().Be(1);
    }

}