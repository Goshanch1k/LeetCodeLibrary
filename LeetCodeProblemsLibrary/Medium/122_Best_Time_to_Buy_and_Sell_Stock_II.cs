using System;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Medium;

public static class MaxProfit122 {
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    public static int MaxProfit(int[] prices) {
        var profit = 0;
        var buyPrice = prices[0];
        var sellPrice = prices[0];
        
        foreach (var currentPrice in prices)
        {
            if (currentPrice > sellPrice)
                sellPrice = Math.Max(sellPrice, currentPrice);
            else
            {
                profit += sellPrice - buyPrice;
                buyPrice = currentPrice;
                sellPrice = currentPrice;
            }
        }
        
        if (sellPrice != buyPrice)
            profit += sellPrice - buyPrice;
        
        return profit;
    }
}