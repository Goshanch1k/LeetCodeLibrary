using System;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Medium;

public class MaxSumDivThree1262 {
    public static int MaxSumDivThree(int[] nums) {
        return MySolution(nums);
    }

    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    private static int MySolution(int[] nums)
    {
        int sum = 0;

        int minimumRemainderOne = 1001;
        int secondMinimumRemainderOne = 1001;
        int minimumRemainderTwo = 1001;
        int secondMinimumRemainderTwo = 1001;

        foreach (int num in nums)
        {
            if (num % 3 == 1 && num <= secondMinimumRemainderOne)
            {
                if (num < minimumRemainderOne)
                {
                    secondMinimumRemainderOne = minimumRemainderOne;
                    minimumRemainderOne = num;
                }
                else
                    secondMinimumRemainderOne = num;
            }

            if (num % 3 == 2 && num <= secondMinimumRemainderTwo)
            {
                if (num < minimumRemainderTwo)
                {
                    secondMinimumRemainderTwo = minimumRemainderTwo;
                    minimumRemainderTwo = num;
                }
                else
                    secondMinimumRemainderTwo = num;
            }

            sum += num;
        }

        if (sum % 3 == 1)
            return sum - Math.Min(minimumRemainderOne, minimumRemainderTwo + secondMinimumRemainderTwo);

        if (sum % 3 == 2)
            return sum - Math.Min(minimumRemainderTwo, minimumRemainderOne + secondMinimumRemainderOne);

        return sum;
    }
}