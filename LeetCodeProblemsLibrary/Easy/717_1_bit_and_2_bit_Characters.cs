using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Easy;

public static class IsOneBitCharacter717 {
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    public static bool IsOneBitCharacter(int[] bits)
    {
        var counter = 0;
        
        if (bits.Length == 1)
            return true;
        
        for (var i = bits.Length - 2; i >= 0; i--)
        {
            if (bits[i] == 1)
                counter++;
            else
                break;
        }
        
        return counter % 2 == 0;
    }
}