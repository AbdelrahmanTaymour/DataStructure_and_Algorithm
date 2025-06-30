namespace DSA_Implementations.ALG___Sorting;

public class QuickSort
{
    private static Random rand = new Random();

    public static void Sort(int[] array)
    {
        QuickSortHelper(array, 0, array.Length - 1);
    }
    private static void QuickSortHelper(int[] arr, int low, int high)
    {
        while (low < high)
        {
            int pi = RandomizedPartition(arr, low, high);
            if(pi == arr.Length - 3)
                Console.WriteLine(arr[pi]);

            // Recurse on smaller partition first (Tail Call Optimization)
            if (pi - low < high - pi)
            {
                QuickSortHelper(arr, low, pi - 1);
                low = pi + 1;  // Tail call elimination on the right
            }
            else
            {
                QuickSortHelper(arr, pi + 1, high);
                high = pi - 1; // Tail call elimination on the left
            }
        }
    }

    private static int RandomizedPartition(int[] arr, int low, int high)
    {
        int pivotIndex = rand.Next(low, high + 1);
        Swap(arr, pivotIndex, high); // Move random pivot to end
        return Partition(arr, low, high);
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    private static void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    // public static void Main()
    // {
    //     int[] arr = { 24, 3, 45, 29, 15, 10, 8, 55, 2 };
    //     Console.WriteLine("Original array: " + string.Join(", ", arr));
    //
    //     QuickSortHelper(arr, 0, arr.Length - 1);
    //
    //     Console.WriteLine("Sorted array:   " + string.Join(", ", arr));
    // }
}