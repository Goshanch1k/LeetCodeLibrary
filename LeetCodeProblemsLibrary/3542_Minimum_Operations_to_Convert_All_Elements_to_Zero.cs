using System.Collections.Generic;

namespace LeetCodeProblemsLibrary;

public static class MinOperations3542 {
    public static int MinOperations(int[] nums)
    {
        Stack<int> stack = new Stack<int>();

        int operationsCount = 0;

        foreach (int num in nums)
        {
            while (stack.Count > 0 && stack.Peek() > num)
            {
                stack.Pop();
            }

            if (num == 0)
            {
                continue;
            }

            if (stack.Count != 0 && stack.Peek() >= num)
            {
                continue;
            }

            operationsCount++;
            stack.Push(num);
        }

        return operationsCount;
    }
}