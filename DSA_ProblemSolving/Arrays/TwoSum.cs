namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// Leetcode problem: Two Sum
/// - https://leetcode.com/problems/two-sum/
/// 
/// Problem Statement:
/// Given an array of integers `nums` and an integer `target`, return the indices of the two numbers
/// such that they add up to `target`.
/// You may assume that each input has exactly one solution, and you may not use the same element twice.
/// You can return the answer in any order.
///
/// Approach (Hash Map for Complement Lookup):
/// - Iterate through the array and calculate the complement for each number: `target - currentNumber`.
/// - Store previously seen numbers in a dictionary, mapping number → index.
/// - For each number, check if its complement already exists in the dictionary:
///   - If found, return the indices.
///   - If not, store the current number with its index for future lookup.
///
/// Algorithm Analysis:
/// - Time Complexity: O(n), where `n` is the number of elements in the array.
/// - Space Complexity: O(n), for storing numbers in the dictionary.
/// </summary>
public class TwoSum
{
    public int[] FindTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(nums[0], 0);

        for (int i = 1; i < nums.Length; i++)
        {
            int numToFind = target - nums[i];

            // If the complement exists, return the pair of indices
            if (dict.TryGetValue(numToFind, out int foundIndex))
                return [i, foundIndex];

            // Store the current number and its index in the dictionary
            dict[nums[i]] = i;
        }
        return Array.Empty<int>();
    }
}