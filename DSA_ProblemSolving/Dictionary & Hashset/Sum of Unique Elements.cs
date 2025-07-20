namespace DSA_ProblemSolving.Dictionary___Hashset;

// LeetCode problem - https://leetcode.com/problems/sum-of-unique-elements/

public class Sum_of_Unique_Elements
{
    public int SumOfUnique(int[] nums) {
        int sum = 0;
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if(!freq.ContainsKey(num)) freq.Add(num, 1);
            else freq[num]++;
        }
        foreach (var element in freq)
        {
            if(element.Value == 1) sum += element.Key;
        }
        return sum;
    }
}