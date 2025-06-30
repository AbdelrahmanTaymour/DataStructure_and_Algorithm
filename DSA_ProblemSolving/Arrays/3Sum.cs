namespace DSA_ProblemSolving.Arrays;

// LeetCode Problem: 3Sum - https://leetcode.com/problems/3sum/
//
// Problem:
// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
// 
// The solution set must not contain duplicate triplets.
//
// Example:
// Input: nums = [-1, 0, 1, 2, -1, -4]
// Output: [[-1, -1, 2], [-1, 0, 1]]
//
// Input: nums = [0, 1, 1]
// Output: []
//
// Input: nums = [0, 0, 0]
// Output: [[0, 0, 0]]
//
// Constraints:
// - 3 <= nums.length <= 3000
// - -10^5 <= nums[i] <= 10^5

public class _3Sum {
    
    /// <summary>
    /// Finds all unique triplets in the array that sum up to zero.
    /// Time Complexity: O(n²) | Space Complexity: O(1) excluding the output space
    /// </summary>
    public static IList<IList<int>> ThreeSum(int[] nums) {
        var res = new List<IList<int>>();
        int n = nums.Length;
        
        // Early return if the nums array has less than 3 elements
        if (n < 3) return res;
        
        // Sort the nums array to handle duplicates and enable two-pointer technique
        Array.Sort(nums);

        // Fix the first element of triplet and use two pointers for remaining elements
        // We need n-2 because we need space for left and right pointers
        for (int i = 0; i < n - 2; i++) {
            
            
            // Skip duplicates for the first element to avoid duplicate triplets
            // Example: [-1,-1,0,1] -> Skip second -1 as it would create duplicate triplets
            if (i > 0 && nums[i] == nums[i - 1]) 
                continue;
            
            // Optimization: if the first number is positive, the sum can't be zero
            // as an array is sorted and all remaining numbers will be larger
            if (nums[i] > 0) 
                break;

            // Use two pointers technique to find the remaining two numbers
            int left = i + 1;      // pointer after current element
            int right = n - 1;     // pointer at the end of the array
            
            while (left < right) {
                // Calculate current sum of triplet
                int sum = nums[i] + nums[left] + nums[right];
                
                if (sum == 0) {
                    // Found valid triplet, add to result
                    res.Add(new List<int> { nums[i], nums[left], nums[right] });
                    
                    // Move both pointers inward
                    left++; 
                    right--;
                    
                    // Skip duplicate values for left pointer
                    // Example: [-2,0,0,0,2,2] -> Skip duplicate 0s
                    while (left < right && nums[left] == nums[left - 1]) 
                        left++;
                    
                    // Skip duplicate values for right pointer
                    // Example: [-2,0,2,2,2] -> Skip duplicate 2s
                    while (left < right && nums[right] == nums[right + 1]) 
                        right--;
                }
                else if (sum < 0) {
                    // Current sum too small, need larger values, move the left pointer
                    left++;
                }
                else {
                    // Current sum too large, need smaller values, move the right pointer
                    right--;
                }
            }
        }
        return res;
    }
}


// Solves the 3Sum problem using the two-pointer technique after sorting the array.
//
// Steps:
// 1. Sort the array to simplify duplicate checking and two-pointer logic.
// 2. Iterate through the array, treating each number as a potential first element of a triplet.
//    - Skip it if it's a duplicate of the previous number.
//    - Stop early if the current number is greater than 0 (no possible triplet can sum to 0).
// 3. For each element, use two pointers (left and right) to find a pair that, with the current element, sums to zero.
// 4. Skip duplicate values for both pointers to avoid repeated triplets.
//
// Time Complexity: O(n^2), where n is the length of the array.
// Space Complexity: O(1), not counting the output list.