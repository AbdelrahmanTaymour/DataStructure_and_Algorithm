namespace DSA_Implementations.ALG___Sorting;

public class SelectionSort
{
    //Worst Case: O(N^2)
    //Average Case: O(N^2)
    //Best Case: O(N^2)
    static void Swap(ref int x, ref int y)
    {
        (x, y) = (y, x);
    }
    public static int[] Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int smallestIndex = i;
            for (int j = i+1; j < n; j++)
            {
                if(arr[smallestIndex] > arr[j]) 
                    smallestIndex = j;
            }
            Swap(ref arr[i], ref arr[smallestIndex]);
        }

        return arr;
    }

    // public static void Main(string[] args)
    // {
    //     int[] arr = new[] { 0,2,5, 6, 8, 4, 2, 9 };
    //     Sort(arr);
    //     Console.WriteLine(string.Join(",", arr));
    // }
}