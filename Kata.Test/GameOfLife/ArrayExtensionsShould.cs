﻿using FluentAssertions;
using Kata.Src.GameOfLife;
using System;
using System.Linq;
using Xunit;

namespace Kata.Test.GameOfLife;

public class ArrayExtensionsShould
{
    [Fact]
    public void Clone2dArrays()
    {
        int[][] original = [[1, 2, 3], [4, 5, 6, 7], [8, 9]];
        original.DeepClone().Should().BeEquivalentTo(original);
    }

    [Fact]
    public void CloneArrayIsDeepClone()
    {
        int[][] original = [[1, 2, 3], [4, 5, 6, 7], [8, 9]];

        var cloned = Mutate(original.DeepClone(), v => v * -1);
        
        var flat = original.SelectMany(row => row).ToArray();
        var flatCloned = cloned.SelectMany(row => row).ToArray();

        flat.Should().NotBeEquivalentTo(flatCloned);
    }

    private static T[][] Mutate<T>(T[][] source, Func<T, T> mutator)
    {
        for (var i = 0; i < source.Length; i++)
        {
            for (var j = 0; j < source[i].Length; j++)
            {
                source[i][j] = mutator(source[i][j]);
            }
        }

        return source;
    }

    [Theory]
    [InlineData(0, 0, new[] { 2, 4, 5 })]
    [InlineData(0, 1, new[] { 1, 3, 4, 5, 6 })]
    [InlineData(0, 2, new[] { 2, 5, 6 })]
    [InlineData(1, 0, new[] { 1, 2, 5, 7, 8 })]
    [InlineData(1, 1, new[] { 1, 2, 3, 4, 6, 7, 8, 9 })]
    [InlineData(1, 2, new[] { 2, 3, 5, 8, 9 })]
    [InlineData(2, 0, new[] { 4, 5, 8 })]
    [InlineData(2, 1, new[] { 4, 5, 6, 7, 9 })]
    [InlineData(2, 2, new[] { 5, 6, 8 })]
    public void GetNeighbours(int row, int col, int[] expectedNeighbours)
    {
        int[][] numberGrid = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        numberGrid
            .GetNeighbours(row, col)
            .ToArray()
            .Should()
            .BeEquivalentTo(expectedNeighbours);
    }   
}