using System;
using System.Collections.Generic;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Medium;

public static class NumberOfSubstrings3234 {
    public static int NumberOfSubstrings(string s) {
        return PrefixSum(s);
    }

    [TimeComplexity("O(n * sqrt(n))")]
    [SpaceComplexity("O(n)")]
    private static int PrefixSum(string s)
    {
        int result = 0;

        int[] prefixOnesSum = new int[s.Length + 1];
        List<int> zeroesIndexes = new List<int>();

        for (int i = 0; i < s.Length; i++)
        {
            prefixOnesSum[i + 1] = prefixOnesSum[i] + (s[i] == '1' ? 1 : 0);

            if (s[i] == '0')
                zeroesIndexes.Add(i);
        }

        int startPos = 0;
        while (startPos < s.Length)
        {
            if (s[startPos] == '0')
            {
                startPos++;
                continue;
            }

            int endPos = startPos;
            while (endPos < s.Length && s[endPos] == '1')
                endPos++;

            int lenOfOnes = endPos - startPos;

            result += lenOfOnes * (lenOfOnes + 1) / 2;
            
            startPos = endPos;
        }

        var zeroLimit = Math.Sqrt(s.Length) + 1;

        for (int numberOfZero = 0; numberOfZero < zeroesIndexes.Count; numberOfZero++)
        {
            var leftMinBorder = numberOfZero == 0 ? 0 : zeroesIndexes[numberOfZero - 1] + 1;
            var leftMaxBorder = zeroesIndexes[numberOfZero];

            for (int countOfZeroes = 1; countOfZeroes <= zeroLimit; countOfZeroes++)
            {
                int lastZeroIndex = numberOfZero + countOfZeroes - 1;

                if (lastZeroIndex >= zeroesIndexes.Count)
                    break;

                int rightMinBorder = zeroesIndexes[lastZeroIndex];
                int rightMaxBorder = lastZeroIndex + 1 < zeroesIndexes.Count ? zeroesIndexes[lastZeroIndex + 1] - 1 : s.Length - 1;

                if (rightMinBorder > rightMaxBorder)
                    continue;

                int targetNumber = countOfZeroes * countOfZeroes;
                int minimalLastPosition = rightMinBorder;

                for (int i = leftMinBorder; i <= leftMaxBorder; i++)
                {
                    if (prefixOnesSum[rightMaxBorder + 1] - prefixOnesSum[i] < targetNumber)
                        continue;

                    while (minimalLastPosition <= rightMaxBorder && prefixOnesSum[minimalLastPosition + 1] - prefixOnesSum[i] < targetNumber)
                        minimalLastPosition++;

                    if (minimalLastPosition > rightMaxBorder)
                        break;

                    result += rightMaxBorder - minimalLastPosition + 1;
                }
            }
        }

        return result;
    }

    [TimeComplexity("O(n^2)")]
    [SpaceComplexity("O(1)")]
    private static int FullIterations(string s)
    {
        var result = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var counterOnes = 0;
            var counterZeroes = 0;
            for (int j = i; j < s.Length; j++)
            {
                if (s[j] == '1')
                    counterOnes++;
                else
                    counterZeroes++;

                // possible square of 10^4
                if (counterZeroes * counterZeroes <= counterOnes)
                    result++;
            }
        }

        return result;
    }
}