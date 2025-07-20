namespace DSA_ProblemSolving.Dictionary___Hashset;

// Leetcode problem: https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array

public class Find_All_Numbers_Disappeared_in_an_Array
{
    public IList<int> FindDisappearedNumbers(int[] nums) {
        HashSet<int> numbers = new HashSet<int>(nums);
        List<int> disappearedNumbers = new List<int>();

        for (int i = 1; i<= nums.Length; i++)
        {
            if(!numbers.Contains(i)) disappearedNumbers.Add(i);
        }
        return disappearedNumbers;
    }
}