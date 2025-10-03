namespace DSA_ProblemSolving.Arrays;

// Leetcode Problem: Find Triangular Sum
// - https://leetcode.com/problems/find-triangular-sum/
//
// Problem Statement:
// Given a 0-indexed integer array `nums`, the triangular sum of `nums` is calculated as follows:
// 1. Create a new array `newNums` with length equal to `nums.Length - 1`.
// 2. For each index `i` where 0 <= i < nums.Length - 1, set newNums[i] = (nums[i] + nums[i+1]) % 10.
// 3. Repeat the process with `newNums` until only one element remains.
// 4. Return the only element remaining.
// 
// Example 1:
// Input: nums = [1,2,3,4,5]
// Output: 8
// Explanation:
// [1, 2, 3, 4, 5]
// [3, 5, 7, 9]
// [8, 2, 6]
// [0, 8]
// [8]
// The triangular sum is 8.
// 
// Example 2:
// Input: nums = [5]
// Output: 5
// Explanation: Since there is only one element in nums, the triangular sum is 5.
// 
// Constraints:
// - 1 ≤ nums.length ≤ 1000
// - 0 ≤ nums[i] ≤ 9
public class FindTriangularSum
{
    // Approach:
    // - Reduce the array size iteratively by replacing each pair of adjacent elements with their sum modulo 10.
    // - Use an outer loop to track the current size of the array (starting from nums.Length down to 1).
    // - Use an inner loop to update each element in-place with (nums[j] + nums[j+1]) % 10.
    // - Continue until only one element remains.
    // - Return the final remaining element at index 0.

    // Algorithm Analysis:
    // - Time Complexity: O(n^2), where `n` is the length of the input array.
    //   The outer loop runs n-1 times, and the inner loop runs (n-1), (n-2), ..., 1 times,
    //   resulting in (n-1)*n/2 operations.
    // - Space Complexity: O(1), as the algorithm modifies the array in-place without using extra space.

    public static int TriangularSum(int[] nums) {
        for(int i = nums.Length; i > 1; i--){
            for(int j = 0; j < i-1; j++){
                nums[j] = (nums[j] + nums[j+1]) % 10;
            }
        }
        return nums[0];
    }
}