namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Insertion Sort algorithm, which builds the final sorted array one item at a time.
/// Similar to sorting playing cards in your hands, where you insert each card into its proper position.
/// </summary>
public class InsertionSort
{
    /// <summary>
    /// Sorts an array using the Insertion Sort algorithm in descending order.
    /// Time Complexity:
    ///     - Worst Case: O(n²) - Array is sorted in the opposite order
    ///     - Average Case: O(n²) - Random array
    ///     - Best Case: O(n) - Array is already sorted
    /// Space Complexity: O(1) - In-place sorting algorithm
    /// </summary>
    /// <param name="arrayToSort">The array to be sorted</param>
    /// <returns>The sorted array in descending order</returns>
    public static int[] Sort(int[] arrayToSort)
    {
        // Start from the second element (index 1)
        // as a single element is already sorted
        for (int i = 1; i < arrayToSort.Length; i++)
        {
            // Store the current element that needs to be inserted
            // into the sorted portion of the array
            int currentElement = arrayToSort[i];
            
            // Start comparing with previous elements
            int compareIndex = i - 1;
            
            // Move elements that are greater than the currentElement
            // to one position ahead of their current position
            // Note: < is used for descending order (change to > for ascending)
            while (compareIndex >= 0 && arrayToSort[compareIndex] < currentElement)
            {
                // Shift an element to the right to make space
                arrayToSort[compareIndex + 1] = arrayToSort[compareIndex];
                compareIndex--;
            }
            
            // Place currentElement in its correct position
            // compareIndex + 1 is used because the while loop
            // decremented one extra time
            arrayToSort[compareIndex + 1] = currentElement;
        }
        
        return arrayToSort;
    }
}