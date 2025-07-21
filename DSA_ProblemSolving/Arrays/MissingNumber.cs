namespace DSA_ProblemSolving.Arrays;

// Leetcode: https://leetcode.com/problems/missing-number

public class Missing_Number
{
    public int MissingNumber(int[] nums) {
        int sum = 0;
        for(int i=1; i<=nums.Length; i++) sum+=i;
        foreach(int num in nums) sum -= num;
        return sum;
    }
}