namespace LeetCodeProblemsLibrary.Medium;

public static class SmallestRepunitDivByK1015
{
    public static int SmallestRepunitDivByK(int k)
    {
        return MySolution(k);
    }

    private static int MySolution(int k)
    {
        if (k % 2 == 0 || k % 5 == 0)
            return -1;

        var counter = 0;
        var result = 0;

        while (counter < k)
        {
            counter = (counter * 10 + 1) % k;
            if (counter == 0)
                return result + 1;

            result++;
        }

        return -1;
    }
}