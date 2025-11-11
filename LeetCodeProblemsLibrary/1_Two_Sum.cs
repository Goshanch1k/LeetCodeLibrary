using System;
using System.Collections.Generic;

namespace LeetCodeProblemsLibrary;

public static class TwoSum1 {
    public static int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new();
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];
            if (map.TryGetValue(complement, out var value))
                return [value, i];
            map[nums[i]] = i;
        }
        return [];
    }
}