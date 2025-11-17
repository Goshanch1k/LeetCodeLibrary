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
}