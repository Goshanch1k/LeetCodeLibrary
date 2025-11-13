using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary;

public static class MaxOperations3228 {
    public static int MaxOperations(string s) {
        return PrefixSum(s);
    }

    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    private static int PrefixSum(string s) {
        var sum = 0;
        
        var onesCount = 0;
        
        var previewsOne = false;
        
        foreach (var binaryChar in s)
        {
            if (binaryChar == '1')
            {
                onesCount++;
                previewsOne = true;
            }
            else 
            {
                if (previewsOne)
                    sum += onesCount;
                
                previewsOne = false;
            }
        }
        
        return sum;
    }
}