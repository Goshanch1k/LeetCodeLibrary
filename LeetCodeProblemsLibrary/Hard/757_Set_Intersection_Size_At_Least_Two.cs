using System;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Hard;

public static class IntersectionSizeTwo757 
{
    public static int IntersectionSizeTwo(int[][] intervals)
    {
        return MySolution(intervals);
    }

    private static int LeetCodeSolution(int[][] intervals)
    {
        Array.Sort(intervals, (first, second) => {
            int firstStart = first[0], firstEnd = first[1];
            int secondStart = second[0], secondEnd = second[1];
            return firstEnd == secondEnd ? secondStart.CompareTo(firstStart) : firstEnd.CompareTo(secondEnd);
        });

        int pointCount = 2; 
        int n = intervals.Length;
        
        int lastPoint = intervals[0][1];
        int secondLastPoint = lastPoint - 1;
        
        for (int i = 1; i < n; i++) {
            int currentStart = intervals[i][0];
            int currentEnd = intervals[i][1];
            
            if (secondLastPoint >= currentStart) continue;
            
            bool hasNoOverlapWithLastPoint = currentStart > lastPoint;
            
            if (hasNoOverlapWithLastPoint) {
                pointCount += 2;
                secondLastPoint = currentEnd - 1;
                lastPoint = currentEnd;
            } else {
                pointCount += 1;
                secondLastPoint = lastPoint;
                lastPoint = currentEnd;
            }
        }
        
        return pointCount;
    }

    [TimeComplexity("O(n * log(n))")]
    [SpaceComplexity("O(1)")]
    private static int MySolution(int[][] intervals)
    {
        Array.Sort(intervals, (first, second) => {
            int firstStart = first[0], firstEnd = first[1];
            int secondStart = second[0], secondEnd = second[1];
            return firstEnd == secondEnd ? secondStart.CompareTo(firstStart) : firstEnd.CompareTo(secondEnd);
        });

        var count = 2;
        var lastPointEnd = intervals[0][1];
        var secondLastPointEnd = lastPointEnd - 1;

        for (int i = 1; i < intervals.Length; i++)
        {
            var currentStart = intervals[i][0];
            var currentEnd = intervals[i][1];

            if (secondLastPointEnd >= currentStart) 
                continue;

            if (currentStart <= lastPointEnd)
            {
                count++;
                secondLastPointEnd = lastPointEnd;
                lastPointEnd = currentEnd;
                continue;
            }
            
            count += 2;
            secondLastPointEnd = currentEnd - 1;
            lastPointEnd = currentEnd;
        }
        
        return count;
    }
}