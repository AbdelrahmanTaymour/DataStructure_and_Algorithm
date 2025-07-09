using System.Text;

namespace DSA_ProblemSolving.Arrays;

// Leetcode problem - Integer To Roman: https://leetcode.com/problems/integer-to-roman/
//
// Problem Explanation:
// Roman numerals are represented by seven different symbols: I, V, X, L, C, D, and M. Each symbol has a defined value:
// I: 1, V: 5, X: 10, L: 50, C: 100, D: 500, M: 1000.
// Given an integer, the task is to convert it to a roman numeral. The solution must respect the general rules of numeral construction,
// such as combining symbols and subtractive notation (e.g., IV represents 4, IX represents 9, etc.).
// The result must be valid, according to the rules of Roman numerals.

public class IntegerToRoman
{
    /// <summary>
    /// Approach:
    /// This solution takes a greedy approach to convert an integer into a Roman numeral. 
    /// 1. Start by defining the Roman symbols along with their values in descending order. 
    /// 2. Iterate through the values and for each value, repeatedly subtract it from the given number (num) 
    ///    until it is no longer possible while appending the corresponding Roman symbol to the result.
    /// 3. The greedy approach ensures that the largest possible Roman numeral is used at each step, 
    ///    which minimizes the number of symbols required and adheres to Roman numeral rules.
    /// 4. Repeat the process until `num` becomes zero, ensuring the final result string is the Roman numeral representation of the input integer.
    ///
    /// Algorithm Analysis:
    /// - Time Complexity: O(1)
    ///   Since the number of Roman numeral symbols and their corresponding values is fixed (13 symbols in total), 
    ///   the algorithm's complexity is independent of the input size. Each symbol is processed at most once within the loop.
    /// - Space Complexity: O(1)
    ///   The space required by the solution is constant because it only uses a fixed-size array for symbols and values 
    ///   and a StringBuilder to store the result. The output size does not depend on the input size directly.
    /// </summary>

    public static string IntToRoman(int num)
    {
        // Define Roman numeral symbols and their corresponding values
        // The arrays are sorted in descending order so that we can process the largest values first.
        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        StringBuilder res = new StringBuilder(); 

        // Iterate through each Roman numeral value from largest to smallest (greedy approach).
        for (int i = 0; i < values.Length && num > 0; i++)
        {
            // While the current Roman numeral value can be subtracted from 'num',
            // append the corresponding symbol to the result and reduce 'num'.
            while (num >= values[i])
            {
                res.Append(symbols[i]); // Append the Roman numeral symbol.
                num -= values[i];      // Subtract the value from 'num'.
            }
        }

        return res.ToString();
    }
}