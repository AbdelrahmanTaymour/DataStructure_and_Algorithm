namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// Leetcode problem: Maximum Subarray - https://leetcode.com/problems/maximum-subarray/
/// 
/// Problem Statement:
/// Given an integer array nums, find the contiguous subarray (containing at least one number)
/// which has the largest sum and return its sum.
///
/// Approach (Kadane’s Algorithm):
/// - Initialize two variables: curSum to store the current running sum,
///   and maxSoFar to store the maximum subarray sum found so far.
/// - Iterate through the array from index 1.
/// - At each step, decide whether to:
///   - Continue the existing subarray by adding the current number, or
///   - Start a new subarray from the current number.
/// - Update the maximum sum if the current running sum is greater than the current maximum.
/// - Return the maximum sum found.
///
/// Algorithm Analysis:
/// - Time Complexity: O(n), Only one pass through the array is needed.
/// - Space Complexity: O(1), constant space is used.
///
/// Constraints:
/// - 1 ≤ nums.length ≤ 10⁵
/// - -10⁴ ≤ nums[i] ≤ 10⁴
/// </summary>
public class Maximum_Subarray
{
    public int MaxSubArray(int[] nums)
    {
        // Initialize current sum and the max sum with the first element
        int maxSoFar = nums[0];
        int curSum = nums[0];

        // Start iterating from the second element
        for (int i = 1; i < nums.Length; i++)
        {
            // At each index, choose the max between:
            // 1. Starting a new subarray from the current element
            // 2. Extending the previous subarray with the current element
            curSum = Math.Max(nums[i], curSum + nums[i]);

            // Update max sum if the current sum is greater
            maxSoFar = Math.Max(maxSoFar, curSum);
        }

        return maxSoFar;
    }
}