using FluentAssertions;
using Kata.Src.MarsRover;
using Xunit;

namespace Kata.Test.MarsRover
{
    public class RoverShould
    {
        [Theory]
        [InlineData("", "0:0:N")]
        [InlineData("L", "0:0:W")]
        [InlineData("LL", "0:0:S")]
        [InlineData("LLL", "0:0:E")]
        [InlineData("LLLL", "0:0:N")]
        [InlineData("M", "0:1:N")]
        [InlineData("MMMMMMMMMM", "0:0:N")]
        [InlineData("MMRMMLM", "2:3:N")]
        public void ReturnExpectedStateAfterExecutingCommands(string commands, string expectedPosition) => 
            new Rover()
                .Execute(commands)
                .Should()
                .Be(expectedPosition);

        [Fact]
        public void ReturnExpectedStateAfterHittingAnObstacle() => 
            new Rover(new Grid(10, 10, new Position(0, 3)))
                .Execute("MMMM")
                .Should()
                .Be("O:0:2:N");
    }
}
