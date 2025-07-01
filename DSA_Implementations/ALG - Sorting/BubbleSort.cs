namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Bubble Sort algorithm, which repeatedly steps through the list,
/// compares adjacent elements and swaps them if they are in the wrong order.
/// </summary>
public class BubbleSort
{
    /// <summary>
    /// Sorts an array using the Bubble Sort algorithm with optimization for already sorted sequences.
    /// Time Complexity:
    /// - Worst Case: O(n²) when array is reverse sorted
    /// - Average Case: O(n²)
    /// - Best Case: O(n) when array is already sorted
    /// Space Complexity: O(1) - in-place sorting
    /// </summary>
    /// <param name="arrayToSort">The array to be sorted</param>
    /// <returns>The sorted array</returns>
    /// <remarks>
    /// Features:
    /// - Stable sorting algorithm
    /// - In-place sorting
    /// - Adaptive (stops early if array becomes sorted)
    /// - Simple implementation
    /// - Good for small data sets
    /// - Not suitable for large datasets
    /// </remarks>
    public static int[] Sort(int[] arrayToSort)
    {
        int arrayLength = arrayToSort.Length;

        for (int i = 0; i < arrayLength; i++)
        {
            // Flag to detect if any swapping occurred in this pass
            bool isSwapped = false;
            
            // Last iteration elements are already in place
            for (int j = 0; j < arrayLength - i - 1; j++)
            {
                // Compare adjacent elements
                if (arrayToSort[j] > arrayToSort[j + 1])
                {
                    // Swap elements if they are in the wrong order
                    Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                    isSwapped = true;
                }
            }

            // If no swapping occurred, means array is sorted
            if (!isSwapped)
                break;
        }
       
        return arrayToSort;
    }

    /// <summary>
    /// Swaps two elements using tuple deconstruction.
    /// </summary>
    /// <param name="first">First element to swap</param>
    /// <param name="second">Second element to swap</param>
    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }
}