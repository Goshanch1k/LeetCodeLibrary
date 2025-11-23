using System.Collections.Generic;
using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Medium;

public static class CountPalindromicSubsequence1930 {
    public static int CountPalindromicSubsequence(string s) {
        return MySolution(s);
    }

    [TimeComplexity("O(n + alphabet.length * (n + n)) = O(n)")]
    [SpaceComplexity("O(alphabet.length) = O(1)")]
    private static int MySolution(string s) {
        HashSet<char> uniqueCharacters = [];
        foreach (char letter in s)
            uniqueCharacters.Add(letter);
        
        int count = 0;
        foreach (char letter in uniqueCharacters)
        {
            var firstIndex = -1;
            var lastIndex = 0;
            
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != letter)
                    continue;
                
                if (firstIndex == -1)
                    firstIndex = i;
                    
                lastIndex = i;
            }
            
            if (lastIndex - firstIndex < 2)
                continue;
            
            HashSet<char> betweenChars = [];
            for (int i = firstIndex + 1; i < lastIndex; i++)
                betweenChars.Add(s[i]);
            
            count += betweenChars.Count;
        }
        
        return count;
    }
}