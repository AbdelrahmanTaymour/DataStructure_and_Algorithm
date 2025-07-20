namespace DSA_ProblemSolving.Arrays;

// Leetcode problem: https://leetcode.com/problems/isomorphic-strings

public class Isomorphic_Strings
{
    public bool IsIsomorphic(string s, string t) {
        if(s.Length != t.Length) return false;
        int[] SMap = new int[256];
        int[] TMap = new int[256];
        
        for(int i = 0; i<s.Length; i++){
            if(SMap[s[i]] != TMap[t[i]]) return false;
            SMap[s[i]] = i + 1;
            TMap[t[i]] = i + 1;
        }
        return true;
    }
}