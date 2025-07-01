namespace DSA_Implementations.ALG___Searching;

/// <summary>
/// Implements the Binary Search algorithm, which efficiently finds a target value in a sorted array
/// by repeatedly dividing the search interval in half.
/// </summary>
public class BinarySearch
{
    /// <summary>
    /// Searches for a target value in a sorted array using the Binary Search algorithm.
    /// Time Complexity: O(log n) - where n is the length of the array
    /// Space Complexity: O(1) - uses only a constant amount of extra space
    /// </summary>
    /// <param name="sortedArray">The sorted array to search in (must be in ascending order)</param>
    /// <param name="target">The value to find in the array</param>
    /// <returns>
    /// The index of the target value if found; otherwise, returns -1
    /// </returns>
    /// <remarks>
    /// Prerequisites:
    /// - The input array must be sorted in ascending order
    /// - The array should not contain duplicate elements for consistent results
    /// 
    /// Example:
    /// array = [1, 2, 3, 4, 5, 6, 7], target = 5
    /// Returns: 4 (index where 5 is located)
    /// </remarks>
    public static int BinarySearchIterative(int[] sortedArray, int target)
    {
        // Initialize the search boundaries
        int leftBound = 0;
        int rightBound = sortedArray.Length - 1;

        // Continue searching while the boundaries haven't crossed
        while (leftBound <= rightBound)
        {
            // Calculate middle index using overflow-safe formula
            int middleIndex = leftBound + (rightBound - leftBound) / 2;

            // Check if we found the target
            if (sortedArray[middleIndex] == target)
                return middleIndex;

            if (sortedArray[middleIndex] > target)
            {
                // Target is in the left half
                rightBound = middleIndex - 1;
            }
            else
            {
                // Target is in the right half
                leftBound = middleIndex + 1;
            }
        }

        // Target was not found in the array
        return -1;
    }
}