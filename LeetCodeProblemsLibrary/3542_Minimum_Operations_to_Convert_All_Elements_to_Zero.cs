using System.Collections.Generic;

namespace LeetCodeProblemsLibrary;

public static class MinOperations3542 {
    public static int MinOperations(int[] nums)
    {
        var stack = new Stack<int>();
        
        foreach (var num in nums)
        {
            if (num == 0)
                continue;

            if (stack.TryPeek(out var previewsNum) && previewsNum < num)
            {
                stack.Pop();
                stack.Push(num);
            }
            else
                stack.Push(num);
            
            
        }
        
        return 0;
    }
}