using System.Text;

namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// Leetcode problem: Longest Common Prefix - https://leetcode.com/problems/longest-common-prefix/
/// 
/// Problem Statement:
/// Write a function to find the longest common prefix string amongst an array of strings.
/// If there is no common prefix, return an empty string "".
/// 
/// Approach:
/// - Start by assuming the entire first string is the common prefix.
/// - Iterate character by character through the first string.
/// - For each character index, check that all other strings have the same character at that index.
/// - If a mismatch is found or a string ends, return the current prefix.
/// - If all characters match for all strings, return the full prefix.
/// 
/// Algorithm Analysis:
/// - Time Complexity: O(n), In the worst case, all strings are the same and we compare every character.
/// - Space Complexity: O(1) additional space, aside from the result string.
/// 
/// Constraints:
/// - 1 ≤ strs.length ≤ 200
/// - 0 ≤ strs[i].length ≤ 200
/// - strs[i] consists of only lowercase English letters.
/// 
/// </summary>
public class Longest_Common_Prefix
{
    public static string GetLongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";
        StringBuilder prefix = new StringBuilder();

        // Iterate through each character of the first string in the array
        for (int i = 0; i < strs[0].Length; i++)
        {
            // Take the current character from the first string as reference
            char currentChar = strs[0][i];

            // Compare the current character with the character at the same index in all other strings
            foreach (string str in strs)
            {
                // If the current index exceeds the length of a string
                // OR if there's a mismatch in character, return the prefix found so far
                if (i >= str.Length || str[i] != currentChar)
                    return prefix.ToString();
            }

            // If all strings have the same character at this index, append it to the prefix
            prefix.Append(currentChar);
        }
        
        return prefix.ToString();
    }
}