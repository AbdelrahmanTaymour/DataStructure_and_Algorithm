namespace DSA_ProblemSolving.Dictionary___Hashset;

/// <summary>
/// Leetcode Problem: Find Common Characters  
/// - https://leetcode.com/problems/find-common-characters/
/// 
/// Problem Statement:
/// Given an array `words` of strings, return a list of all characters that show up in all strings within the list (including duplicates).
/// You may return the answer in any order.
///
/// Example:
/// Input: ["bella", "label", "roller"]
/// Output: ["e", "l", "l"]
///
/// Input: ["cool", "lock", "cook"]
/// Output: ["c", "o"]
///
/// Approach (Frequency Intersection):
/// - Step 1: Initialize an array `minFreq` of size 26 (a-z) with int.MaxValue.
///           This array will hold the minimum frequency of each character across all words.
/// - Step 2: For each word:
///     - Count character frequencies in a local array `charFreq` of size 26.
///     - Update `minFreq` by taking the minimum value between current and `charFreq[i]`.
/// - Step 3: Build the result list by including each character `minFreq[i]` times (if > 0).
///
/// Key Insight:
/// - A character can only be considered "common" if it appears in all words.
///   So we find the minimum frequency of each character across all words.
///
/// Algorithm Analysis:
/// - Time Complexity: O(N * K), where N = number of words, K = average length of each word
/// - Space Complexity: O(1), since the frequency arrays have constant size (26 letters)
///
/// </summary>
public class Find_Common_Characters
{
    public static IList<string> CommonChars(string[] words)
    {
        // Track the minimum frequency of each character (a-z) across all words
        int[] minFreq = new int[26];
        Array.Fill(minFreq, int.MaxValue);

        // For each word, calculate character frequency and update minFreq
        foreach (string word in words)
        {
            int[] charFreq = new int[26];
            foreach (char c in word)
            {
                charFreq[c - 'a']++;
            }

            // Update the global minimum frequency for each character
            for (int i = 0; i < 26; i++)
            {
                minFreq[i] = Math.Min(minFreq[i], charFreq[i]);
            }
        }

        // Build the result from characters that appear in all words
        List<string> result = new List<string>();
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < minFreq[i]; j++)
            {
                result.Add(((char)(i + 'a')).ToString());
            }
        }

        return result;
    }
}