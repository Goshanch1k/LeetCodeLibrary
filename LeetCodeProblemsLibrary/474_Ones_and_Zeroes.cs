using System;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary;

public static class FindMaxForm474 {
    [TimeComplexity("O(m * n * strs.length)")]
    [SpaceComplexity("O(m * n)")]
    public static int FindMaxForm(string[] strs, int m, int n) {
        int[][] memory = new int[m + 1][];
		
        for(int i = 0; i <= m; i++)
            memory[i] = new int[n + 1];
		
        foreach(string str in strs)
        {
            int zero = 0, one = 0;
            foreach (char c in str)
            {
                if (c == '0')
                    zero++;
                else
                    one++;
            }
			
            for(int i = m; i >= zero; i--)
            {
                for(int j = n; j >= one; j--)
                    memory[i][j] = Math.Max(memory[i][j], memory[i - zero][j - one] + 1);
            }
        }
		
        return memory[m][n];
    }
}