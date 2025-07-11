using System.Text;

namespace DSA_ProblemSolving.Arrays;

// Leetcode problem: Reverse Words in a String
// - https://leetcode.com/problems/reverse-words-in-a-string/
// 
// Problem Statement:
// Given an input string `s`, reverse the order of the words.
// A word is defined as a sequence of non-space characters.
// The words in `s` will be separated by at least one space.
// Return a string with the words in reverse order, separated by a single space,
// and with no leading or trailing spaces.
//
// Approach:
// - Use a "ReadOnlySpan<char>" to efficiently read the string without allocating new substrings.
// - Use "stackalloc" to create a stack-based buffer to store the start index and length of each word.
// - Iterate through the input and extract words by skipping spaces and reading non-space segments.
// - Store each word’s (start, length) in the "words" span.
// - Then build the result string using a "StringBuilder", appending words in reverse order.
// 
// Performance:
// - Time Complexity: O(n), where n is the length of the input string.
//   We scan the input once to extract words, and again to rebuild the output.
// - Space Complexity: O(n), where n is the number of words (stack-allocated) + for the output string.

public class Reverse_Words_in_a_String
{
    public string ReverseWords(string s)
    {
        ReadOnlySpan<char> span = s;

        // Use stack-allocated span to hold start index and length of each word
        Span<(int start, int length)> words = stackalloc (int, int)[span.Length / 2 + 1];
        int wordCount = 0;

        int i = 0;
        while (i < span.Length)
        {
            // Skip any leading spaces
            while (i < span.Length && span[i] == ' ') i++;

            int start = i;

            // Read until next space to get the word
            while (i < span.Length && span[i] != ' ') i++;

            int length = i - start;

            // Only add non-empty words
            if (length > 0)
            {
                words[wordCount++] = (start, length);
            }
        }

        // Build the result in reverse order using StringBuilder
        var sb = new StringBuilder(s.Length);
        for (int j = wordCount - 1; j >= 0; j--)
        {
            var (start, length) = words[j];
            sb.Append(span.Slice(start, length));
            if (j > 0)
                sb.Append(' ');
        }

        return sb.ToString();
    }
}