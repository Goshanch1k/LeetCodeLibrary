using System;

namespace LeetCodeProblemsLibrary.Attributes;

public static class MinOperations2654 {
    public static int MinOperations(int[] nums)
    {
        return SlidingWindow(nums);
    }
    
    [TimeComplexity("O(n^2 * logM)", "M=max(nums)")]
    [SpaceComplexity("O(1)")]
    private static int SlidingWindow(int[] nums)
    {
        var countOnes = 0;
        var gdcCounter = nums[0];
        foreach (var num in nums)
        {
            if (num == 1)
                countOnes++;

            gdcCounter = GreatestCommonDivisor(gdcCounter, num);
        }
        
        if (countOnes > 0)
            return nums.Length - countOnes;

        if (gdcCounter > 1)
            return -1;

        var minLen = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            var currentGcd = 0;
            for (int j = i; j < nums.Length; j++)
            {
                currentGcd = GreatestCommonDivisor(currentGcd, nums[j]);
                
                if (currentGcd != 1)
                    continue;
                
                minLen = Math.Min(minLen, j - i + 1);
                break;
            }   
        }
        
        return minLen + nums.Length - 2;
    }
    
    
    private static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}