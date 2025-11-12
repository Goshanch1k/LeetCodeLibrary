using System;

namespace LeetCodeProblemsLibrary;

public static class SortedSquares977 {
    public static int[] SortedSquares(int[] nums) {
        int[] result = new int[nums.Length];
        int left = 0, right = nums.Length - 1;

        for(int i = result.Length - 1; i >= 0 ; i--)
        {
            if(Math.Abs(nums[left]) >  Math.Abs(nums[right]))
            {
                result[i] = nums[left] * nums[left];
                left++;
            }
            else
            {
                result[i] = nums[right] * nums[right];
                right--;
            }  
        }

        return result;
    }
}