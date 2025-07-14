namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// Leetcode problem: Trapping Rain Water
/// - https://leetcode.com/problems/trapping-rain-water/
/// 
/// Problem Statement:
/// Given `n` non-negative integers representing an elevation map where the width of each bar is 1,
/// compute how much water it can trap after raining.
///
/// Approach (Two-Pointer Technique):
/// - Use two pointers `left` and `right` starting from both ends of the array.
/// - Track the maximum height seen so far from the left (`maxLeft`) and from the right (`maxRight`).
/// - At each step, move the pointer with the smaller height:
///   - If the current height is less than the max seen so far, water can be trapped there.
///   - Otherwise, update the max for that side.
/// - Repeat until both pointers meet.
///
/// Algorithm Analysis:
/// - Time Complexity: O(n), where `n` is the number of bars.
///   Each index is visited at most once.
/// - Space Complexity: O(1), constant space used.
/// </summary>
public class Trapping_Rain_Water
{
    public static int GetTrappingRainwater(int[] heights)
    {
        int totalWater = 0;
        int left = 0, right = heights.Length - 1;

        // Track the highest wall seen from the left and right so far
        int maxLeft = 0, maxRight = 0;

        // Process until the two pointers meet
        while (left < right)
        {
            // If the left side is shorter or equal to the right side
            if (heights[left] <= heights[right])
            {
                if (heights[left] >= maxLeft)
                {
                    // Update maxLeft if current is higher
                    maxLeft = heights[left];
                }
                else
                {
                    // Water can be trapped, calculate the difference
                    totalWater += maxLeft - heights[left];
                }

                // Move the left pointer to the right
                left++;
            }
            else
            {
                if (heights[right] >= maxRight)
                {
                    // Update maxRight if current is higher
                    maxRight = heights[right];
                }
                else
                {
                    // Water can be trapped, calculate the difference
                    totalWater += maxRight - heights[right];
                }

                // Move the right pointer to the left
                right--;
            }
        }

        // Return the total trapped water
        return totalWater;
    }
}
