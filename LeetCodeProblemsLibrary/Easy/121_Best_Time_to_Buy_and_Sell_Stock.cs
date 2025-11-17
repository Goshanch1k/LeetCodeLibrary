using System;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Easy;

public static class MaxProfit121
{
    public static int MaxProfit(int[] prices) => Kadane(prices);
    
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    private static int Kadane(int[] prices)
    {
        int min = prices[0];
        int maxProfit = int.MinValue;
       
        for(int i = 1; i < prices.Length; i++)
        {
            int profit = prices[i] - min;

            min = Math.Min(min, prices[i]);
           
            maxProfit = Math.Max(maxProfit, profit);
        }
       
        return maxProfit <= 0 ? 0 : maxProfit;
    }
    
    // TODO: Not solved
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    private static int TwoPointers(int[] prices)
    {
        var maxProfit = 0;
        
        if (prices.Length == 1)
            return maxProfit;
        
        if (prices.Length == 2)
            return Math.Max(0, prices[1] - prices[0]);
        
        var rightIndex = 0;
        var leftIndex = 1;

        while (leftIndex < prices.Length - 1)
        {
            maxProfit = Math.Max(maxProfit, prices[leftIndex] - prices[rightIndex]);

            if (rightIndex + 1 == leftIndex)
            {
                leftIndex++;
                continue;
            }

            if (prices[rightIndex] - prices[rightIndex + 1] >= prices[leftIndex + 1] - prices[leftIndex])
                rightIndex++;
            else
                leftIndex++;                
        }

        while (rightIndex < leftIndex)
        {
            maxProfit = Math.Max(maxProfit, prices[leftIndex] - prices[rightIndex]);
            rightIndex++;
        }
        
        return maxProfit;
    }
}