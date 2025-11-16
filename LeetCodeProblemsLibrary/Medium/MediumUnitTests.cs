using System.Collections.Generic;
using LeetCodeProblemsLibrary.Attributes;
using Xunit;

namespace LeetCodeProblemsLibrary.Medium;

public class MediumUnitTests
{

    [Theory]
    [LeetCodeTags("Array", "Prefix-Sum", "Difference Array")]
    [MemberData(nameof(TestData2536))]
    public void RangeAddQueries2536_Test(int n, int[][] queries, int[][] expected)
    {
        // Arrange & Act
        var result = RangeAddQueries2536.RangeAddQueries(n, queries);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [LeetCodeTags("String", "Prefix-Sum")]
    [InlineData("00011", 5)]
    [InlineData("101101", 16)]
    public void NumberOfSubstrings3234_Test(string s, int expected)
    {
        // Arrange & Act
        var result = NumberOfSubstrings3234.NumberOfSubstrings(s);

        // Assert
        Assert.Equal(expected, result);
    }
    
    public static IEnumerable<object[]> TestData2536()
    {
        yield return
        [
            3,
            new int[][] 
            {
                [1, 1, 2, 2],
                [0, 0, 1, 1]
            },
            new int[][] 
            {
                [1, 1, 0],
                [1, 2, 1],
                [0, 1, 1]
            }
        ];
    }
}
