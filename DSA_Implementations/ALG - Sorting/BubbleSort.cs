namespace DSA_Implementations.ALG___Sorting;

public class BubbleSort
{
    static void Swap(ref int x, ref int y)
    {
        (x, y) = (y, x);
    }
    public static int[] Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            bool IsSwaped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(ref arr[j], ref arr[j + 1]);
                    IsSwaped = true;
                }
            }
            if(!IsSwaped) break;
        }
       
        return arr;
    }
    // public static void Main(string[] args)
    // {
    //     int[] arr = new[] { 0,2,5, 6, 8, 4, 2, 9 };
    //     int[] sortedArr = new[] { 0, 2, 2, 4, 5, 6, 8, 9 };
    //     Sort(sortedArr);
    //     Console.WriteLine(string.Join(",", arr));
    // }
}