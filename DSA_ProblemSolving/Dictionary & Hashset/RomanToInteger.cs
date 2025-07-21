namespace DSA_ProblemSolving.Dictionary___Hashset;

public class RomanToInteger
{
    public int RomanToInt(string s) {
        Dictionary<char, int> roman = new Dictionary<char, int> {
            {'I', 1}, {'V', 5}, {'X', 10},
            {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };
        
        int n = s.Length;
        int result = roman[s[n-1]];
        
        for(int i = n-2; i >= 0; i--) {
            if(roman[s[i]] < roman[s[i+1]]) {
                result -= roman[s[i]];
            } else {
                result += roman[s[i]];
            }
        }
        
        return result;
    }
}