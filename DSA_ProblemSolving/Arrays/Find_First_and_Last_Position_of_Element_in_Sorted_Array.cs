namespace DSA_ProblemSolving.Arrays;

public class Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    /// <summary>
    /// Leetcode problem: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
    /// 
    /// Finds the first and last position of a target element in a sorted array using binary search.
    /// If the target is not found, returns [-1, -1].
    /// </summary>
    /// 
    /// <remarks>
    /// Time Complexity: O(log N), where N is the length of the input array.
    /// - The function `FindBound` is called twice (for the first and last occurrence), each taking O(log N) due to binary search.
    ///
    /// Space Complexity: O(1).
    /// - The algorithm uses constant space, as no additional data structures are used.
    /// </remarks>
    public static int[] SearchRange(int[] nums, int target)
    {
        // Initialize the result array with [-1, -1] to signify "not found".
        int[] res = { -1, -1 };

        // Edge case: return result immediately if the input array is empty.
        if (nums.Length == 0) return res;
        
        // Find the first occurrence of the target.
        res[0] = FindBound(nums, target, isFirst: true);

        // If the first occurrence is found, find the last occurrence as well.
        // If not found, the result remains [-1, -1].
        res[1] = FindBound(nums, target, isFirst: false);
        
        // Return the range of the target in the array.
        return res;
    }

    /// <summary>
    /// Helper function to find a boundary (first or last occurrence) of the target element.
    /// </summary>
    /// <param name="nums">The input sorted array of integers.</param>
    /// <param name="target">The target element to find.</param>
    /// <param name="isFirst">Flag indicating whether to find the first or last boundary.</param>
    /// <returns>
    /// The index of the target element's boundary (first or last). 
    /// Returns -1 if the target is not found.
    /// </returns>
    private static int FindBound(int[] nums, int target, bool isFirst)
    {
        // Initialize pointers for binary search: 'left' and 'right'.
        int left = 0, right = nums.Length - 1;

        // Variable to store the index of the found boundary.
        int bound = -1;

        // Perform binary search on the array.
        while (left <= right)
        {
            // Calculate the middle index to avoid overflow.
            int mid = left + (right - left) / 2;

            // Check if the middle element equals the target.
            if (nums[mid] == target)
            {
                // If target is found, store the index (potential boundary).
                bound = mid;

                // Adjust the search range based on whether we're finding the first or last occurrence:
                if (isFirst)
                {
                    // To find the first occurrence, search in the left (smaller indexes).
                    right = mid - 1;
                }
                else
                {
                    // To find the last occurrence, search in the right (larger indexes).
                    left = mid + 1;
                }
            }
            else if (nums[mid] < target)
            {
                // If the middle element is less than the target, discard the left half.
                left = mid + 1;
            }
            else
            {
                // If the middle element is greater than the target, discard the right half.
                right = mid - 1;
            }
        }

        // Return the found boundary or -1 if the target is not present.
        return bound;
    }

}