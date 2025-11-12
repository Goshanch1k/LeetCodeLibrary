using Xunit;
using System.Linq;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary;

public class UnitTests
{
    [Theory]
    [LeetCodeTags("Array", "Hash Table", "Two Pointers", "Prefix Sum")]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void TwoSum1_Test(int[] nums, int target, int[] expected)
    {
        // Arrange & Act
        var result = TwoSum1.TwoSum(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Dynamic Programming", "Knapsack 01")]
    [InlineData(new[] { "10", "0001", "111001", "1", "0" }, 5, 3, 4)]
    [InlineData(new[] { "10", "0", "1" }, 1, 1, 2)]
    public void FindMaxForm474_Test(string[] strs, int m, int n, int expected)
    {
        // Arrange & Act
        var result = FindMaxForm474.FindMaxForm(strs, m, n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Array", "Two Pointers")]
    [InlineData(new[] { 0, 1, 2, 3, 4, 5 }, new[] { 0, 1, 4, 9, 16, 25 })]
    [InlineData(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
    [InlineData(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
    public void SortedSquares977_Test(int[] nums, int[] expected)
    {
        // Arrange & Act
        var result = SortedSquares977.SortedSquares(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory(Skip = "Not solved")]
    [InlineData(new[] { 1, 0, 2, 3, 0, 4, 5, 0 }, new[] { 1, 0, 0, 2, 3, 0, 0, 4 })]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    public void DuplicateZeros1089_Test(int[] input, int[] expected)
    {
        // Arrange & Act
        var array = input.ToArray();

        // Act
        DuplicateZeros1089.DuplicateZeros(array);

        // Assert
        Assert.Equal(expected, array);
    }

    [Theory]
    [LeetCodeTags("Array", "Sliding-Window", "Segment-Tree")]
    [InlineData(new[] { 2, 6, 3, 1 }, 3)]
    [InlineData(new[] { 2, 1, 1, 1 }, 1)]
    [InlineData(new[] { 2, 6, 1, 4 }, 3)]
    [InlineData(new[] { 2, 6, 3, 4 }, 4)]
    [InlineData(new[] { 2, 10, 6, 14 }, -1)]
    [InlineData(new[] { 6, 10, 15 }, 4)]
    [InlineData(new[] { 48841, 93382, 993143, 170438, 48860, 174356, 291531 }, 7)]
    public void MinOperations2654_Test(int[] nums, int expected)
    {
        // Arrange & Act
        var result = MinOperations2654.MinOperations(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Stack", "Monotonic-Stack", "Greedy")]
    [InlineData(new[] { 0, 2 }, 1)]
    [InlineData(new[] { 3, 1, 2, 1 }, 3)]
    [InlineData(new[] { 1, 2, 1, 2, 1, 2 }, 4)]
    public void MinOperations3542_Test(int[] nums, int expected)
    {
        // Arrange & Act
        var result = MinOperations3542.MinOperations(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}