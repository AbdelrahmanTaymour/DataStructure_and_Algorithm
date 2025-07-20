namespace DSA_ProblemSolving.Dictionary___Hashset;

public class Find_Element_Not_In_Another_Array
{
    public IList<int> FindElements(int[] nums1, int[] nums2)
    {
        HashSet<int> arr2Set = new HashSet<int>(nums2);
        List<int> result = new List<int>();

        foreach (int num in nums1)
        {
            if(!arr2Set.Contains(num)) result.Add(num);
        }
        return result;
    }
}