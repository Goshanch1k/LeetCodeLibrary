using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Medium;

public static class RangeAddQueries2536 {
    // More correct if we use multidimensional arrays
    [TimeComplexity("O(n^2 * q)", "q = queries.length")]
    [SpaceComplexity("O(n^2)")]
    public static int[][] RangeAddQueries(int n, int[][] queries)
    {
        var diffMatrix = CalculateDiffMatrix(n, n, queries);
        
        // In this problem, calculate a prefix sum of diff matrix its result

        foreach (var row in diffMatrix)
        {
            var prefixSum = 0;
            for (int j = 0; j < row.Length; j++)
            {
                prefixSum += row[j];
                row[j] = prefixSum;
            }
        }
        
        return diffMatrix;
    }

    private static int[][] CalculateDiffMatrix(int rows, int cols, int[][] queries)
    {
        int[][] diffMatrix = new int[rows][];
        for (int i = 0; i < rows; i++)
            diffMatrix[i] = new int[cols];
        
        foreach (var query in queries)
        {
            var row1 = query[0];
            var col1 = query[1];
            var row2 = query[2];
            var col2 = query[3];
            
            for (int i = row1; i <= row2; i++)
            {
                diffMatrix[i][col1]++;
                if (col2 + 1 < cols)
                    diffMatrix[i][col2 + 1]--;
            }
        }        
        
        return diffMatrix;
    }
}