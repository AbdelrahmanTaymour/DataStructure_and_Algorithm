namespace DSA_ProblemSolving.Dictionary___Hashset;

/// <summary>
/// Leetcode Problem: Check If The SentenceIs Pangram  
/// - https://leetcode.com/problems/check-if-the-sentence-is-pangram/
/// 
/// Problem Statement:
/// A pangram is a sentence where every letter of the English alphabet appears at least once.
/// Given a string sentence containing only lowercase English letters,
/// return true if sentence is a pangram, or false otherwise.
/// 
/// </summary>
public class Check_If_The_SentenceIs_Pangram
{
    public static bool IsPangram(string sentence) {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        HashSet<char> set = new HashSet<char>(sentence);

        foreach(char c in alphabet){
            if(!set.Contains(c)) return false;
        }
        return true;
    }
    public static bool IsPangram2(string sentence)
    {
        HashSet<char> letters = new HashSet<char>();
        foreach (char c in sentence.ToLower())
        {
            if (char.IsLetter(c))
                letters.Add(c);
        }
        return letters.Count == 26;
    }
}