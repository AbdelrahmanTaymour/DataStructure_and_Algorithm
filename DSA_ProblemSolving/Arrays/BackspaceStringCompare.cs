namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// LeetCode Problem: Backspace String Compare - https://leetcode.com/problems/backspace-string-compare/
/// </summary>

public class BackspaceStringCompare
{
    /// <summary>
    /// Compares two strings after processing backspace characters, using a two-pointer approach
    /// working from right to left.
    /// </summary>
    /// <param name="s">First input string containing letters and backspace characters</param>
    /// <param name="t">Second input string containing letters and backspace characters</param>
    /// <returns>True if both strings are equal after processing backspaces, false otherwise</returns>
    /// <remarks>
    /// Time Complexity: O(N + M) where N and M are lengths of input strings
    /// Space Complexity: O(1) as we only use constant extra space
    /// 
    /// Algorithm:
    /// 1. Start from the end of both strings using two pointers
    /// 2. For each string:
    ///    - Count consecutive '#' characters (each represents a backspace)
    ///    - Skip characters based on the number of backspaces
    /// 3. Compare actual characters after processing backspaces
    /// 4. Return false if characters don't match or if strings have different lengths
    /// 
    /// Example:
    /// Input: s = "ab#c", t = "ad#c"
    /// Output: true
    /// Explanation: Both strings resolve to "ac"
    /// </remarks>

    public static bool BackspaceCompare(string s, string t) //TIME: O(A + B) | SPACE: O(1)
    {
        // Initialize pointers to the end of both strings
        int p1 = s.Length - 1, p2 = t.Length - 1;

        while (p1 >= 0 || p2 >= 0) {
            // Process string s from right to left
            int skipS = 0; // Counter for backspaces in string s
            while (p1 >= 0) {
                if (s[p1] == '#') {
                    // Found a backspace, increment counter and move left
                    skipS++;
                    p1--;
                }
                else if (skipS > 0) {
                    // Character needs to be skipped due to previous backspace
                    skipS--;
                    p1--;
                }
                else {
                    // Found a valid character that won't be deleted
                    break;
                }
            }

            // Process string t from right to left (same logic as above)
            int skipT = 0; // Counter for backspaces in string t
            while (p2 >= 0) {
                if (t[p2] == '#') {
                    skipT++;
                    p2--;
                }
                else if (skipT > 0) {
                    skipT--;
                    p2--;
                }
                else {
                    break;
                }
            }

            // Compare characters after processing backspaces
            if (p1 >= 0 && p2 >= 0) {
                // Both strings have characters to compare
                if (s[p1] != t[p2]) return false; // Characters don't match
            }
            else {
                // One string has characters while the other doesn't
                // If either pointer is still valid, strings are different
                if (p1 >= 0 || p2 >= 0) return false;
            }
        
            // Move to next characters
            p1--; 
            p2--;
        }
    
        // If we've processed both strings completely, they're equal
        return true;
    }
}