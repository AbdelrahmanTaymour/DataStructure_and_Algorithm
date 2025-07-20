namespace DSA_ProblemSolving.Arrays;

// Leetcode problem: https://leetcode.com/problems/majority-element/

public class Majority_Element
{
    public int MajorityElement(int[] nums) {
        int count=0, majorityElement=0;
        for(int i=0; i<nums.Length; i++){
            if(count == 0) majorityElement = nums[i];
            if(majorityElement == nums[i]) count++;
            else count--;
        }
        return majorityElement;
    }
}