using FluentAssertions;
using Kata.Src.MarsRover;
using Xunit;

namespace Kata.Test.MarsRover
{
    public class RoverStateShould
    {
        private static readonly Grid StandardGrid = new(10, 10);
        private static readonly RoverState InitialState = new(new Position(0, 0), Facing.North);

        [Theory]
        [InlineData(Facing.North, Facing.West)]
        [InlineData(Facing.West, Facing.South)]
        [InlineData(Facing.South, Facing.East)]
        [InlineData(Facing.East, Facing.North)]
        public void BeInExpectedStateWhenRotateLeft(Facing startFacing, Facing expectedFacing)
        {
            var startState = InitialState with { Facing = startFacing };
            var expectedState = InitialState with { Facing = expectedFacing };
            startState.RotateLeft().Should().Be(expectedState);
        }

        [Theory]
        [InlineData(Facing.North, Facing.East)]
        [InlineData(Facing.East, Facing.South)]
        [InlineData(Facing.South, Facing.West)]
        [InlineData(Facing.West, Facing.North)]
        public void BeInExpectedStateWhenRotateRight(Facing startFacing, Facing expectedFacing)
        {
            var startState = InitialState with { Facing = startFacing };
            var expectedState = InitialState with { Facing = expectedFacing };
            startState.RotateRight().Should().Be(expectedState);
        }

        [Fact]
        public void BeInExpectedStateWhenMovesNorth()
        {
            var startState = new RoverState(new Position(0, 0), Facing.North);
            var expectedState = new RoverState(new Position(0, 1), Facing.North);
            startState.MoveOn(StandardGrid).Should().Be(expectedState);
        }

        [Fact]
        public void BeInExpectedStateWhenMovesSouth()
        {
            var startState = new RoverState(new Position(0, 1), Facing.South);
            var expectedState = new RoverState(new Position(0, 0), Facing.South);
            startState.MoveOn(StandardGrid).Should().Be(expectedState);
        }

        [Fact]
        public void BeInExpectedStateWhenMovesWest()
        {
            var startState = new RoverState(new Position(1, 0), Facing.West);
            var expectedState = new RoverState(new Position(0, 0), Facing.West);
            startState.MoveOn(StandardGrid).Should().Be(expectedState);
        }

        [Fact]
        public void BeInExpectedStateWhenMovesEast()
        {
            var startState = new RoverState(new Position(0, 0), Facing.East);
            var expectedState = new RoverState(new Position(1, 0), Facing.East);
            startState.MoveOn(StandardGrid).Should().Be(expectedState);
        }

        [Fact]
        public void StopMovingWhenHitsObstacle()
        {
            var obstacleGrid = new Grid(10, 10, new Position(0, 3));
            var startState = new RoverState(new Position(0, 2), Facing.North);
            var expectedState = startState with { HitObstacle = true };
            startState.MoveOn(obstacleGrid).Should().Be(expectedState);
        }   
    }
}