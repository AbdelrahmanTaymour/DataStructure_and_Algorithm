namespace DSA_ProblemSolving.Dictionary___Hashset;

public class Character_Frequency
{
    public IDictionary<char, int> CharFrequencyCounter(string input)
    {
        Dictionary<char, int> charFrequency = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (!charFrequency.TryAdd(c, 1))
            {
                charFrequency[c]++;
            }
        }
        return charFrequency;
    }
}