using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Easy;

public class FindFinalValue2154 {
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    public static int FindFinalValue(int[] nums, int original)
    {
        int bitSet = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % original != 0)
                continue;
            
            var potentialBit = nums[i] / original;

            if ((potentialBit & potentialBit - 1) == 0)
                bitSet |= potentialBit;
        }

        bitSet++;

        return original * (bitSet & -bitSet);
    }
}