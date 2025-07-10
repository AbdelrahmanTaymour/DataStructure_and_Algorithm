namespace DSA_ProblemSolving.Arrays;
/// <summary>
/// Leetcode problem - Valid Palindrome II: https://leetcode.com/problems/valid-palindrome-ii/
/// 
/// Problem Statement:
/// Given a string `str`, return true if the string can be a palindrome after deleting at most one character.
/// A palindrome is a string that reads the same backward as forward.
/// 
/// Approach:
/// - Use two pointers: `left` starting from the beginning, and `right` from the end.
/// - Move the pointers toward the center as long as the characters match.
/// - If a mismatch is found, we have one chance to skip either the left or right character
///   and check if the rest of the substring is a palindrome.
/// - Use a helper function `IsAlmostAPalindrome` to check if a substring is a valid palindrome.
/// - Return true if skipping one character results in a valid palindrome; otherwise, return false.
///
/// Algorithm Analysis:
/// - Time Complexity: O(n), where `n` is the length of the string. Each character is checked at most twice.
/// - Space Complexity: O(1), since only pointers are used (no extra memory).
///
/// Constraints:
/// - 1 ≤ s.length ≤ 10⁵
/// - `str` consists of lowercase letters.
/// </summary>
public class Valid_Palindrome_II
{
    public bool AlmostAPalindrome(string str)
    {
        // Edge case: Strings of length 2 or less are always valid with at most one deletion
        if (str.Length <= 2) return true;

        int left = 0, right = str.Length - 1;

        // Two-pointer approach to check characters from both ends
        while (left < right)
        {
            // If characters do not match, try removing one character (either left or right)
            if (str[left] != str[right])
            {
                return IsAlmostAPalindrome(str, left + 1, right) || // Skip left character
                       IsAlmostAPalindrome(str, left, right - 1);   // Skip right character
            }

            // If characters match, move both pointers toward the center
            left++;
            right--;
        }

        // All characters matched without needing to delete more than one
        return true;
    }
    
    private bool IsAlmostAPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}