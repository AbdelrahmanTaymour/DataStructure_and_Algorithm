namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Selection Sort algorithm, which sorts an array by repeatedly
/// finding the minimum element from the unsorted portion and placing it at the beginning.
/// </summary>
public class SelectionSort
{
    /// <summary>
    /// Sorts an array using the Selection Sort algorithm.
    /// Time Complexity: O(n²) for all cases (worst, average, and best)
    /// Space Complexity: O(1) - in-place sorting algorithm
    /// </summary>
    /// <param name="arrayToSort">Array to be sorted</param>
    /// <returns>The sorted array in ascending order</returns>
    /// <remarks>
    /// Selection Sort is:
    /// - Performs well on small arrays
    /// - Uses minimum number of swaps (O(n) swaps)
    /// - Not stable (doesn't preserve order of equal elements)
    /// - Not adaptive (doesn't take advantage of partially sorted arrays)
    /// </remarks>
    public static int[] Sort(int[] arrayToSort)
    {
        int arrayLength = arrayToSort.Length;

        // Iterate through the array
        // Last element will automatically be in the correct position
        for (int i = 0; i < arrayLength - 1; i++)
        {
            // Assume current index contains the minimum value
            int minimumValueIndex = i;

            // Find the minimum element in the unsorted portion
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (arrayToSort[j] < arrayToSort[minimumValueIndex])
                {
                    minimumValueIndex = j;
                }
            }

            // Swap the found minimum element with the first element of the unsorted portion
            if (minimumValueIndex != i)
            {
                Swap(ref arrayToSort[i], ref arrayToSort[minimumValueIndex]);
            }
        }

        return arrayToSort;
    }

    /// <summary>
    /// Swaps two elements in place using tuple deconstruction.
    /// </summary>
    /// <param name="first">First element to swap</param>
    /// <param name="second">Second element to swap</param>
    private static void Swap(ref int first, ref int second)
    {
        (first, second) = (second, first);
    }
}