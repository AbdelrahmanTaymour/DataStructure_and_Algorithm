namespace DSA_ProblemSolving.Dictionary___Hashset;

// https://leetcode.com/problems/find-common-characters/

public class Find_All_Disappeared_Numbers
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        List<int> disappearedNumbers = new List<int>();
        bool[] values = new bool[nums.Length+1];

        foreach(int num in nums){
            values[num] = true;
        }
        
        for (int i = 1; i<= nums.Length; i++) {
            if(values[i] == false) 
                disappearedNumbers.Add(i);
        }
        return disappearedNumbers;
    }
}