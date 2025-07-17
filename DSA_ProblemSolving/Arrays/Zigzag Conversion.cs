using System.Text;

namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// Leetcode problem: Zigzag Conversion
/// - https://leetcode.com/problems/zigzag-conversion/
/// 
/// Problem Statement:
/// Given a string `s` and an integer `numRows`, write the string in a zigzag pattern
/// on the given number of rows. Then read the characters row by row to create a new string.
///
/// Example:
/// Input: s = "PAYPALISHIRING", numRows = 3
/// Zigzag pattern:
/// P   A   H   N
/// A P L S I I G
/// Y   I   R
/// Output: "PAHNAPLSIIGYIR"
///
/// Approach 1 (Simulation with Direction Flag):
/// - Simulate row-by-row zigzag by using an array of StringBuilder for each row.
/// - Use a direction flag to toggle when you reach the top or bottom row.
/// - Append each character to the appropriate row and return the final concatenated result.
///
/// Approach 2 (Optimized Index Calculation):
/// - Avoid simulation and calculate character positions directly using the zigzag cycle length (period).
/// - Place characters row by computing exact jump positions.
/// </summary>
public class Zigzag_Conversion
{
    public string Convert(string s, int numRows)
    {
        // Edge case: zigzag is the string itself
        if (numRows == 1 || numRows >= s.Length)
            return s;

        // Initialize a StringBuilder for each row
        StringBuilder[] rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            rows[i] = new();

        int currentRow = 0;
        bool goingDown = false;

        // Simulate zigzag traversal
        foreach (char c in s)
        {
            rows[currentRow].Append(c);

            // Flip direction at first and last row
            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;

            // Move up or down
            currentRow += (goingDown) ? 1 : -1;
        }

        // Combine all rows into one string
        StringBuilder result = new StringBuilder();
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }

    /// <summary>
    /// Optimized zigzag conversion using mathematical index jumping based on period.
    /// </summary>
    public string Convert2(string s, int numRows)
    {
        // Edge case: zigzag is the string itself
        if (numRows == 1 || numRows >= s.Length)
            return s;

        // Allocate result span for performance
        Span<char> result = stackalloc char[s.Length];
        int resultIndex = 0;

        // The zigzag cycle length (i.e., after how many characters the pattern repeats)
        int period = numRows * 2 - 2;

        // For each row, pick characters by jumping using calculated intervals
        for (int row = 0; row < numRows; row++)
        {
            int increment = 2 * row;

            for (int i = row; i < s.Length; i += increment)
            {
                result[resultIndex++] = s[i];

                // Adjust jump size after the first jump to handle zigzag shape
                // Avoid double-writing for the first and last row (increment == 0 or == period)
                if (increment != period)
                {
                    increment = period - increment;
                }
            }
        }

        return result.ToString();
    }
}