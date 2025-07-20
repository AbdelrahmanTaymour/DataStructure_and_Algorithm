namespace DSA_ProblemSolving.Arrays;

// Leetcode problem: https://leetcode.com/problems/keyboard-row/

public class Keyboard_Row
{
    public string[] FindWords(string[] words) {
        string s1 = "qwertyuiopQWERTYUIOP";
        string s2 = "asdfghjklASDFGHJKL";
        string s3 = "zxcvbnmZXCVBNM";

        List<string> w = [];
        foreach (string word in words)
        {
            if (word.All(c => s1.Contains(c))
                || word.All(c => s2.Contains(c))
                || word.All(c => s3.Contains(c)))
            {
                w.Add(word);
            }
        }
        return w.ToArray();
    }
}