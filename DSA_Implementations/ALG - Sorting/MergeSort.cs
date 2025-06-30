namespace DSA_Implementations.ALG___Sorting;

public class MergeSort
{
    public static void Sort(int[] array)
    {
        if (array == null || array.Length <= 1)
            return;
        
        int[] temp = new int[array.Length];
        MergeSortRecursive(array, temp, 0, array.Length - 1);
    }
    private static void MergeSortRecursive(int[] array, int[] temp, int left, int right)
    {
        if(left >= right) 
            return;
        
        int mid = left + (right - left) / 2;
        MergeSortRecursive(array, temp, left, mid);
        MergeSortRecursive(array, temp, mid + 1, right);
        Merge(array, temp, left, mid, right);
    }

    private static void Merge(int[] array, int[] temp, int left, int mid, int right)
    {
        int leftIndex = left;
        int rightIndex = mid+1;
        int tempIndex = left;

        while (leftIndex <= mid && rightIndex <= right)
        {
            if(array[leftIndex] <= array[rightIndex])
                temp[tempIndex++] = array[leftIndex++];
            else
                temp[tempIndex++] = array[rightIndex++];
        }
        
        while(leftIndex <= mid)
            temp[tempIndex++] = array[leftIndex++];

        while (rightIndex <= right)
            temp[tempIndex++] = array[rightIndex++];
        
        for(int i = left; i <= right; i++)
            array[i] = temp[i];
    }

    // public static void Main(string[] args)
    // {
    //     int[] array = { 2,4,5,7,1,2,3,6 };
    //     Sort(array);
    //     Console.WriteLine(string.Join(",", array));
    // }
}