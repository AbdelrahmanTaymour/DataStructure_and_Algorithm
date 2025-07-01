namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Quick Sort algorithm using randomized pivot selection and
/// tail-call optimization for better performance.
/// </summary>
public class QuickSort
{
    private static readonly Random random = new Random();

    /// <summary>
    /// Initiates the Quick Sort algorithm on the given array.
    /// Time Complexity: 
    /// - Average Case: O(n log n)
    /// - Worst Case: O(n²) (rare with randomized pivot)
    /// - Best Case: O(n log n)
    /// Space Complexity: O(log n) average case for recursion stack
    /// </summary>
    /// <param name="arrayToSort">Array to be sorted</param>
    /// <remarks>
    /// Features:
    /// - In-place sorting
    /// - Not stable
    /// - Uses randomized pivot selection
    /// - Implements tail-call optimization
    /// </remarks>
    public static void Sort(int[] arrayToSort)
    {
        QuickSortHelper(arrayToSort, 0, arrayToSort.Length - 1);
    }

    /// <summary>
    /// Recursive helper method that implements the Quick Sort algorithm with
    /// tail-call optimization to reduce stack space usage.
    /// </summary>
    private static void QuickSortHelper(int[] array, int lowIndex, int highIndex)
    {
        while (lowIndex < highIndex)
        {
            // Get partition index using randomized pivot
            int partitionIndex = RandomizedPartition(array, lowIndex, highIndex);

            // Optimize recursion by handling smaller partition first
            if (partitionIndex - lowIndex < highIndex - partitionIndex)
            {
                QuickSortHelper(array, lowIndex, partitionIndex - 1);
                lowIndex = partitionIndex + 1; // Tail call optimization
            }
            else
            {
                QuickSortHelper(array, partitionIndex + 1, highIndex);
                highIndex = partitionIndex - 1; // Tail call optimization
            }
        }
    }

    /// <summary>
    /// Selects a random pivot and partitions the surrounding array.
    /// This helps avoid worst-case scenarios in sorted or nearly sorted arrays.
    /// </summary>
    private static int RandomizedPartition(int[] array, int lowIndex, int highIndex)
    {
        // Select random pivot and move it to the end
        int randomPivotIndex = random.Next(lowIndex, highIndex + 1);
        Swap(array, randomPivotIndex, highIndex);
        return Partition(array, lowIndex, highIndex);
    }

    /// <summary>
    /// Partitions the array around a pivot element (last element).
    /// Elements smaller than the pivot go to the left, larger to the right.
    /// </summary>
    private static int Partition(int[] array, int lowIndex, int highIndex)
    {
        int pivotValue = array[highIndex];
        int smallerElementsIndex = lowIndex - 1;

        // Move elements smaller than pivot to the left side
        for (int i = lowIndex; i < highIndex; i++)
        {
            if (array[i] < pivotValue)
            {
                smallerElementsIndex++;
                Swap(array, smallerElementsIndex, i);
            }
        }

        // Place the pivot in its final position
        Swap(array, smallerElementsIndex + 1, highIndex);
        return smallerElementsIndex + 1;
    }

    /// <summary>
    /// Swaps two elements in the array using tuple deconstruction.
    /// </summary>
    private static void Swap(int[] array, int firstIndex, int secondIndex)
    {
        (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]);
    }
}