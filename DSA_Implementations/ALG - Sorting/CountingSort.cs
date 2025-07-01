namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Counting Sort algorithm, a non-comparative integer sorting algorithm
/// that works by counting the occurrences of each element and placing them in their final sorted positions.
/// </summary>
public class CountingSort
{
    /// <summary>
    /// Sorts an array of non-negative integers using the Counting Sort algorithm.
    /// Time Complexity: O(n + k) where n is an array length and k is the range of input
    /// Space Complexity: O(k) where k is the range of input
    /// </summary>
    /// <param name="arrayToSort">Array of non-negative integers to be sorted</param>
    /// <returns>A new sorted array containing the same elements</returns>
    /// <remarks>
    /// Limitations:
    /// - Only works with non-negative integers
    /// - Not suitable for large ranges of numbers (k)
    /// - Not an in-place sorting algorithm
    /// 
    /// Example:
    /// Input: [4, 2, 2, 8, 3, 3, 1]
    /// Output: [1, 2, 2, 3, 3, 4, 8]
    /// </remarks>
    public static int[] Sort(int[] arrayToSort)
    {
        int arrayLength = arrayToSort.Length;
        
        // Find the maximum value in the array
        int maxValue = FindMaxValue(arrayToSort);
        
        // Create a count array to store the count of each unique number
        int[] countArray = new int[maxValue + 1];
        Array.Fill(countArray, 0);
        
        // Count occurrences of each element
        for (int i = 0; i < arrayLength; i++)
        {
            countArray[arrayToSort[i]]++;
        }

        // Modify the count array to store actual positions
        // of elements in an output array
        for (int i = 1; i <= maxValue; i++)
        {
            countArray[i] += countArray[i - 1];
        }
        
        // Build the output array
        int[] sortedArray = new int[arrayLength];
        // Process array from right to left to maintain stability
        for (int i = arrayLength - 1; i >= 0; i--)
        {
            int currentElement = arrayToSort[i];
            int position = countArray[currentElement] - 1;
            sortedArray[position] = currentElement;
            countArray[currentElement]--;
        }

        return sortedArray;
    }

    /// <summary>
    /// Finds the maximum value in the array.
    /// </summary>
    /// <param name="array">Array to search</param>
    /// <returns>The maximum value in the array</returns>
    private static int FindMaxValue(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

}