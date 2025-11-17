using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Easy;

public static class KLengthApart1437
{
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    public static bool KLengthApart(int[] nums, int k) {
        int lastOnesPosition = -k - 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) 
                continue;
            
            if (i - lastOnesPosition - 1 < k)
                return false;

            lastOnesPosition = i;
        }

        return true;
    }
}