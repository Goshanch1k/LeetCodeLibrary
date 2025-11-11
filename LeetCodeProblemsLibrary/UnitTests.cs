using Xunit;
using System.Linq;

namespace LeetCodeProblemsLibrary
{
    public class UnitTests
    {
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
        
        [Theory]
        [InlineData(new[] { 0, 2 }, 1)]
        [InlineData(new[] { 3, 1, 2, 1 }, 3)]
        [InlineData(new[] { 1, 2, 1, 2, 1, 2 }, 4)]
        public void SquaresOfSortedArray977_Test(int[] nums, int expected)
        {
            // Arrange & Act
            var result = MinOperations3542.MinOperations(nums);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}