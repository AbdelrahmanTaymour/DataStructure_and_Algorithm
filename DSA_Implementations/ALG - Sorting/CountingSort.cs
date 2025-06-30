namespace DSA_Implementations.ALG___Sorting;

public class CountingSort
{
    public static int[] Sort(int[] array)
    {
        int N = array.Length;
        int M = 0;

        foreach (int ele in array)
            M = System.Math.Max(M, ele);
        
        int[] countArray = new int[N];
        Array.Fill(countArray, 0);
        
        for(int i = 0; i < N; i++)
            countArray[array[i]]++;

        for (int i = 1; i < M; i++)
            countArray[i] += countArray[i - 1];
        
        int[] sortedArray = new int[N];
        for(int i = N -1; i >= 0; i--)
        {
            sortedArray[countArray[array[i]] - 1] = array[i];
            countArray[array[i]]--;
        }
        return sortedArray;
    }
}