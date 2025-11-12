using Xunit;
using System.Linq;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary
{
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
        
        [Theory(Skip = "Not solved")]
        [InlineData(new[] { 1, 0, 2, 3, 0, 4, 5, 0 }, new[] { 0, 1, 4, 9, 16, 25 })]
        [InlineData(new[] { 1, 2, 3 }, new[] { 1, 4, 9 })]
        public void SortedSquares997_Test(int[] nums, int[] expected)
        {
            // Arrange & Act
            var result = SortedSquares997.SortedSquares(nums);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Theory(Skip = "Not solved")]
        [InlineData(new[] { 1, 0, 2, 3, 0, 4, 5, 0 }, new[] { 1, 0, 0, 2, 3, 0, 0, 4 })]
        [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        public void DuplicateZeros1089_Test(int[] input, int[] expected)
        {
            
            // Arrange
            var array = input.ToArray(); // Create a copy of input array

            // Act
            DuplicateZeros1089.DuplicateZeros(array);

            // Assert
            Assert.Equal(expected, array);
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
}