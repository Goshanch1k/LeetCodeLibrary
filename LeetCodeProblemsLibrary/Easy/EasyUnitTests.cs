using System.Linq;
using LeetCodeProblemsLibrary.Attributes;
using Xunit;

namespace LeetCodeProblemsLibrary.Easy;

public class EasyUnitTests
{
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