using System.Text;

namespace DSA_ProblemSolving.Sorting;

/// <summary>
/// Leetcode Problem: Sort Characters By Frequency  
/// - https://leetcode.com/problems/sort-characters-by-frequency/
/// 
/// Problem Statement:
/// Given a string `s`, sort it in decreasing order based on the frequency of characters.  
/// Return the sorted string. If multiple characters have the same frequency, their relative order can be arbitrary.
///
/// Example:
/// Input: s = "tree"
/// Output: "eetr" or "eert"
///
/// Input: s = "cccaaa"
/// Output: "aaaccc" or "cccaaa"
///
/// Input: s = "Aabb"
/// Output: "bbAa" or "bbaA" (capital letters are distinct from lowercase)
///
/// Approach (Bucket Sort):
/// - Step 1: Count the frequency of each character using a dictionary.
/// - Step 2: Create an array of buckets, where the index represents the frequency.
///           Each bucket stores a list of characters with that frequency.
/// - Step 3: Traverse the buckets in reverse order (highest frequency first),
///           and for each character in a bucket, append it to the result string `freq` times.
///
/// Key Insight:
/// - Bucket sort is used here because the maximum frequency of any character is at most s.Length,
///   so we can group characters by their frequency efficiently.
///
/// Algorithm Analysis:
/// - Time Complexity: O(n), where n = s.Length
///     - Counting frequencies: O(n)
///     - Bucket sort & result building: O(n)
/// - Space Complexity: O(n)
///     - Dictionary, buckets, and result string
/// </summary>
public class Sort_Characters_by_Frequency
{
    public string FrequencySort(string s)
    {
        // Count frequency of each character
        var frequencyMap = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            if (!frequencyMap.TryAdd(ch, 1))
                frequencyMap[ch]++;
        }

        // Bucket sort: index = frequency, value = list of chars with that frequency
        var buckets = new List<char>[s.Length + 1];
        foreach (var (ch, freq) in frequencyMap)
        {
            buckets[freq] ??= new List<char>();
            buckets[freq].Add(ch);
        }

        // Build the result string from buckets in reverse (highest freq first)
        var result = new StringBuilder();
        for (int freq = buckets.Length - 1; freq > 0; freq--)
        {
            if (buckets[freq] == null) continue;

            foreach (char ch in buckets[freq])
            {
                result.Append(ch, freq); // Append character `freq` times
            }
        }
        return result.ToString();
    }
}