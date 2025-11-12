namespace LeetCodeProblemsLibrary;

public static class DuplicateZeros1089 {
    public static void DuplicateZeros(int[] arr) {
        if (arr.Length == 1) 
            return;

        int i = 0;
        int next = arr[1];
        while (i < arr.Length - 1)
        {
            if (next == 0)
            {
                next = arr[i + 1];
                arr[i + 1] = 0;
                i+=2;
            }
                
            (arr[i], next) = (next, arr[i]);
            i++;
        }
    }
}