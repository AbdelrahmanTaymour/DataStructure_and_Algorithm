namespace DSA_ProblemSolving.Arrays;

// Leetcode problem: Find the index of the First Occurrence in a String
// - https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/
// 
// Problem Statement:
// Given two strings `needle` and `haystack`, the task is to find the index
// of the first occurrence of `needle` in `haystack`. If `needle` is not a part of `haystack`,
// return -1.
// 
// Example 1:
// Input: haystack = "sadbutsad", needle = "sad"
// Output: 0
// Explanation: "sad" occurs at index 0 and 6.
// The first occurrence is at index 0, so we return 0.
// 
// Example 2:
// Input: haystack = "leetcode", needle = "leeto"
// Output: -1
// Explanation: "leeto" did not occur in "leetcode", so we return -1.
// 
// Constraints:
// - 1 ≤ haystack.length, needle.length ≤ 10^4
// - `haystack` and `needle` consist of only lowercase English letters.
public class Find_the_index_of_the_First_Occurrence_in_a_String
{
    // Approach:
    // - Iterate through `haystack` up to `haystack.Length - needle.Length`.
    // - For each index, check if the substring of `haystack` starting from this index matches `needle`.
    // - Use a nested loop for comparing the characters of `needle` and the corresponding characters
    //   in `haystack`.
    // - Break out of the inner loop if there is a mismatch and continue with the next index in the outer loop.
    // - If all characters match, return the current index.
    // - If no occurrence is found throughout the iteration, return -1.

    // Algorithm Analysis:
    // - Time Complexity: O(n * m), where `n` is the length of `haystack` and `m` is the length of `needle`.
    //   Each potential starting index in `haystack` is checked against the entire `needle` in the worst case.
    // - Space Complexity: O(1).

    public static int StrStr(string haystack, string needle)
    {
        // Outer loop traverses each potential starting index of a match
        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            // Check if the first character matches to trigger further comparison
            if (haystack[i] == needle[0])
            {
                // Assume the match is successful until proven otherwise
                bool success = true;

                // Inner loop compares each character of `needle` with `haystack`
                for (int j = 0; j < needle.Length; j++)
                {
                    // Break if any character does not match
                    if (haystack[i + j] != needle[j])
                    {
                        success = false;
                        break;
                    }
                }

                // If all characters of `needle` match, return the starting index
                if (success)
                    return i;
            }
        }

        return -1;
    }
}