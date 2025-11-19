using LeetCodeProblemsLibrary.Attributes;

namespace LeetCodeProblemsLibrary.Easy;

public static class CountOperations2169 {
    [TimeComplexity("O(max(num1, num2))")]
    [SpaceComplexity("O(1)")]
    public static int CountOperations(int num1, int num2) 
    {
        return OptimizedCountOperations(num1, num2);
    }
    
    [TimeComplexity("O(max(num1, num2))")]
    [SpaceComplexity("O(1)")]
    private static int NaiveCountOperations(int num1, int num2) 
    {
        var counter = 0;
        
        while (num1 > 0 && num2 > 0)
        {
            if (num1 > num2)
                num1 -= num2;
            else
                num2 -= num1;
                            
            counter++;
            
            if (num1 == 1)
                return counter + num2;
            
            if (num2 == 1)
                return counter + num1;
        }
        
        return counter;
    }
    
    [TimeComplexity("O(log(min(num1, num2)))")]
    [SpaceComplexity("O(1)")]
    private static int OptimizedCountOperations(int num1, int num2) 
    {
        int res = 0;
        
        while (num1 != 0 && num2 != 0) 
        {
            res += num1 / num2;
            
            num1 %= num2;
            
            (num1, num2) = (num2, num1);
        }
        
        return res;
    }
}