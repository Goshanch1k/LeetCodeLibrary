using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Medium;

public static class NumSub1513 {
    [TimeComplexity("O(n)")]
    [SpaceComplexity("O(1)")]
    public static int NumSub(string s) {
        double result = 0;
        const int massiveNumber = 1000000007;
        
        double counter = 0;
        int i = 0;
        while (i < s.Length)
        {
            while (i < s.Length && s[i] == '1')
            {
                counter++;
                i++;
            }
            
            result = (result + counter * (counter + 1) / 2) % massiveNumber;
            counter = 0;

            i++;
        }
        
        return (int)result;
    }
    
}