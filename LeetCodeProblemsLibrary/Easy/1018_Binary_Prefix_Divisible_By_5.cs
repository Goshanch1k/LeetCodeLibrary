using System.Collections.Generic;

namespace LeetCodeProblemsLibrary.Easy;

public class PrefixesDivByFive1018 {
    public static IList<bool> PrefixesDivBy5(int[] nums) {
        return MySolution(nums);
    }

    private static bool[] MySolution(int[] nums)
    {
        var result = new bool[nums.Length];

        int currentNumber = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            currentNumber = (currentNumber << 1) + nums[i];
            
            result[i] = currentNumber % 5 == 0;
        }
        
        return result;
    }
}