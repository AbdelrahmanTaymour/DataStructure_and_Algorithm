namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Merge Sort algorithm using the divide-and-conquer strategy.
/// Splits the array into smaller subarrays, sorts them, and then merges them back.
/// </summary>
public class MergeSort
{
    /// <summary>
    /// Initiates the Merge Sort algorithm on the given array.
    /// Time Complexity: O(n log n) for all cases
    /// Space Complexity: O(n) for a temporary array
    /// </summary>
    /// <param name="arrayToSort">Array to be sorted</param>
    /// <remarks>
    /// Advantages:
    /// - Stable sorting algorithm
    /// - Guaranteed O(n log n) performance
    /// - Good for sorting linked lists
    /// 
    /// Disadvantages:
    /// - Requires extra space
    /// - Not in-place
    /// - Overkill for small arrays
    /// </remarks>
    public static void Sort(int[] arrayToSort)
    {
        // Handle base cases
        if (arrayToSort == null || arrayToSort.Length <= 1)
            return;
        
        // Create temporary array for merging
        int[] tempArray = new int[arrayToSort.Length];
        MergeSortRecursive(arrayToSort, tempArray, 0, arrayToSort.Length - 1);
    }

    /// <summary>
    /// Recursively divides the array into smaller subarrays and sorts them.
    /// </summary>
    /// <param name="array">Array being sorted</param>
    /// <param name="tempArray">Temporary array for merging</param>
    /// <param name="leftIndex">Start index of current subarray</param>
    /// <param name="rightIndex">End index of current subarray</param>
    private static void MergeSortRecursive(int[] array, int[] tempArray, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) 
            return;
        
        // Calculate middle point
        int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
        
        // Recursively sort left and right halves
        MergeSortRecursive(array, tempArray, leftIndex, middleIndex);
        MergeSortRecursive(array, tempArray, middleIndex + 1, rightIndex);
        
        // Merge the sorted halves
        Merge(array, tempArray, leftIndex, middleIndex, rightIndex);
    }

    /// <summary>
    /// Merges two sorted subarrays into a single sorted array.
    /// </summary>
    /// <param name="array">Original array</param>
    /// <param name="tempArray">Temporary array for merging</param>
    /// <param name="leftIndex">Start of first subarray</param>
    /// <param name="middleIndex">End of first subarray</param>
    /// <param name="rightIndex">End of second subarray</param>
    private static void Merge(int[] array, int[] tempArray, int leftIndex, int middleIndex, int rightIndex)
    {
        int leftSubarrayIndex = leftIndex;
        int rightSubarrayIndex = middleIndex + 1;
        int tempArrayIndex = leftIndex;

        // Compare and merge elements from both subarrays
        while (leftSubarrayIndex <= middleIndex && rightSubarrayIndex <= rightIndex)
        {
            if (array[leftSubarrayIndex] <= array[rightSubarrayIndex])
                tempArray[tempArrayIndex++] = array[leftSubarrayIndex++];
            else
                tempArray[tempArrayIndex++] = array[rightSubarrayIndex++];
        }
        
        // Copy remaining elements from left subarray, if any
        while (leftSubarrayIndex <= middleIndex)
            tempArray[tempArrayIndex++] = array[leftSubarrayIndex++];
        
        // Copy remaining elements from right subarray, if any
        while (rightSubarrayIndex <= rightIndex)
            tempArray[tempArrayIndex++] = array[rightSubarrayIndex++];
        
        // Copy merged elements back to original array
        for (int i = leftIndex; i <= rightIndex; i++)
            array[i] = tempArray[i];
    }
}
