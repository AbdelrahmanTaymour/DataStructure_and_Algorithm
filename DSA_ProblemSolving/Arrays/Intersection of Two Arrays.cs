namespace DSA_ProblemSolving.Arrays;

// Leetcode Problem: https://leetcode.com/problems/intersection-of-two-arrays

public class Intersection_of_Two_Arrays
{
    public int[] Intersection(int[] nums1, int[] nums2) {
        int[] freq = new int[1001];
        List<int> result = new List<int>();

        for (int i = 0; i < nums1.Length; i++)
            freq[nums1[i]]++;
            
        for (int i = 0; i < nums2.Length; i++) {
            if(freq[nums2[i]] != 0) {
                result.Add(nums2[i]);
                freq[nums2[i]] = 0;
            }
        }
        return result.ToArray();
    }
}