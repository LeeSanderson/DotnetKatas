using System;
using FluentAssertions;
using Kata.Src.Bowling;
using Xunit;

namespace Kata.Test.Bowling;

public class FrameShould
{
    [Fact]
    public void BeAStrikeIf10Rolled() => 
        new Frame(1).WithRolls(10).IsStrike.Should().BeTrue();

    [Fact]
    public void BeASpareIfTwoRollsAddTo10() => 
        new Frame(1).WithRolls(6, 4).IsSpare.Should().BeTrue();

    [Fact]
    public void NotBeASpareIfTwoRollsDoNotAddTo10() => 
        new Frame(1).WithRolls(6, 3).IsSpare.Should().BeFalse();

    [Fact]
    public void NotBeASpareIfOnlyRolledOnce() => 
        new Frame(1).WithRolls(6).IsSpare.Should().BeFalse();

    [Fact]
    public void BeTheFinalFrameIfTheFrameNumberIs10() => 
        new Frame(10).IsFinalFrame.Should().BeTrue();

    [Fact]
    public void NotBeTheFinalFrameIfTheFrameNumberIsNot10() => 
        new Frame(1).IsFinalFrame.Should().BeFalse();

    [Fact]
    public void BeCompleteIfRolledStrikeAndNotFinalFrame() => 
        new Frame(1).WithRolls(10).IsComplete.Should().BeTrue();

    [Fact]
    public void BeCompleteIfRolledTwiceAndNotFinalFrame() =>
        new Frame(1).WithRolls(9, 1).IsComplete.Should().BeTrue();

    [Fact]
    public void BeCompleteIfFinalFrameAndFirstRollWasStrikeAndRolled2Extras() =>
        new Frame(10).WithRolls(10, 1, 1).IsComplete.Should().BeTrue();

    [Fact]
    public void BeCompleteIfFinalFrameAndWasSpareAndRolled1Extras() =>
        new Frame(10).WithRolls(9, 1, 1).IsComplete.Should().BeTrue();

    [Fact]
    public void BeCompleteIfFinalFrameRolledTwiceAndNotSpareOrStrike() =>
        new Frame(10).WithRolls(8, 1).IsComplete.Should().BeTrue();

    [Fact]
    public void ReturnRolledRolls() =>
        new Frame(10).WithRolls(8, 1).Rolls.Should().BeEquivalentTo([8, 1]);
}

public static class FrameExtensions
{
    public static Frame WithRolls(this Frame frame, params int[] rolls)
    {
        foreach (var roll in rolls)
        {
            frame.Roll(roll);
        }
        return frame;
    }
}