namespace DSA_Implementations.ALG___Sorting;

public class InsertionSort
{
    //Worst Case: O(N^2)
    //Average Case: O(N^2)
    //Best Case: O(N)
    public static int[] Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i-1; 
            while(j>=0 && arr[j] < key)
            {
                arr[j+1] = arr[j];
                j--;
            }
            arr[j+1] = key;
            Console.WriteLine(string.Join(",", arr));
        }
        return arr;
    }

    // public static void Main(String[] args)
    // {
    //     int[] arr = new[] { 31, 41, 59, 26, 41, 58 };
    //     Sort(arr);
    //     Console.WriteLine(string.Join(",", arr));
    // }
}