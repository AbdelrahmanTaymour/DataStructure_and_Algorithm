namespace DSA_ProblemSolving.Dictionary___Hashset;

// Leetcode Problem: https://leetcode.com/problems/longest-consecutive-sequence

public class Longest_Consecutive_Subsequence
{
    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0) return 0;
        
        Dictionary<int,bool> set = new (nums.Length);
        foreach(var n in nums){
            set[n] = false;
        }
        
        int longestStreak = 1;
        foreach((int num,_) in set){
            if(set.ContainsKey(num - 1)) continue;
            
            int counter = 1;
            while(set.ContainsKey(num + counter)) counter++;
            
            if(counter > longestStreak) longestStreak = counter;
        }
        return longestStreak;
    }
}