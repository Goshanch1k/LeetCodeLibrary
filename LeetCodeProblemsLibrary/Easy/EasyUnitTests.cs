using System.Linq;
using LeetCodeProblemsLibrary.Attributes;
using Xunit;

namespace LeetCodeProblemsLibrary.Easy;

public class EasyUnitTests
{
    [Theory]
    [LeetCodeTags("Array", "Kadane", "Two Pointers")]
    [InlineData(new[] { 6, 1, 3, 2, 4, 7 }, 6)]
    [InlineData(new[] { 3, 2, 6, 5, 0, 3 }, 4)]
    [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [InlineData(new[] { 2, 4, 1, 11, 7 }, 10)]
    [InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
    [InlineData(new[] { 2, 1, 7, 4 }, 6)]
    [InlineData(new[] { 2, 1, 4 }, 3)]
    [InlineData(new[] { 1, 4, 2 }, 3)]
    [InlineData(new[] { 1, 2 }, 1)]
    public void MaxProfit121_Test(int[] nums, int expected)
    {
        // Arrange & Act
        var result = MaxProfit121.MaxProfit(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Array")]
    [InlineData(new[] { 1, 0 }, false)]
    [InlineData(new[] { 1, 0, 0 }, true)]
    [InlineData(new[] { 1, 1, 1, 0 }, false)]
    [InlineData(new[] { 1, 1, 1, 1, 0 }, true)]
    [InlineData(new[] { 1, 1, 1, 1, 1, 0 }, false)]
    public void IsOneBitCharacter717_Test(int[] input, bool expected)
    {
        // Arrange & Act
        var array = input.ToArray();

        // Act
        var result = IsOneBitCharacter717.IsOneBitCharacter(array);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Array")]
    [InlineData(new[] { 1, 0 }, new[] { false, false })]
    [InlineData(new[] { 1, 1, 1, 0 }, new[] { false, false, false, false })]
    [InlineData(new[] { 0, 1, 1 }, new[] { true, false, false })]
    [InlineData(new[] { 1, 1, 1 }, new[] { false, false, false })]
    [InlineData(
        new[]
        {
            1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1,
            1, 1, 0, 0, 1, 0
        },
        new[]
        {
            false, false, true, false, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false, false, true, false, false, true, true,
            true, true, true, true, true, false, false, true, false, false, false, false, true, true
        })]
    public void PrefixesDivByFive1018_Test(int[] input, bool[] expected)
    {
        // Arrange & Act
        var array = input.ToArray();

        // Act
        var result = PrefixesDivByFive1018.PrefixesDivBy5(array);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Array")]
    [InlineData(new[] { 1,0,0,0,1,0,0,1 }, 2, true)]
    [InlineData(new[] { 1,0,0,1,0,1 }, 2, false)]
    public void KLengthApart1437_Test(int[] input, int k, bool expected)
    {
        // Arrange & Act
        var array = input.ToArray();

        // Act
        var result = KLengthApart1437.KLengthApart(array, k);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Array")]
    [InlineData(new[] { 5, 3, 6, 1, 12 }, 3, 24)]
    [InlineData(new[] { 2, 7, 9 }, 4, 4)]
    public void FindFinalValue2154_Test(int[] nums, int original, int expected)
    {
        // Arrange & Act
        var result = FindFinalValue2154.FindFinalValue(nums, original);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [LeetCodeTags("Math")]
    [InlineData(2, 4, 2)]
    [InlineData(3, 1, 3)]
    [InlineData(3, 2, 3)]
    [InlineData(10, 10, 1)]
    public void CountOperations2169_Test(int num1, int num2, int expected)
    {
        // Arrange & Act
        var result = CountOperations2169.CountOperations(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }
}