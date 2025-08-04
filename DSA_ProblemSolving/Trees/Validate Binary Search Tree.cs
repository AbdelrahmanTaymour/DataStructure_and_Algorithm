namespace DSA_ProblemSolving.Trees;

// Leetcode problem: Validate Binary Search Tree
// - https://leetcode.com/problems/validate-binary-search-tree/

public class Validate_Binary_Search_Tree
{
    public bool IsValidBST(TreeNode root) {
        return IsValidBSTHelper(root, long.MinValue, long.MaxValue);
    }
    private bool IsValidBSTHelper(TreeNode node, long min, long max){
        if(node == null) return true;
        
        if(node.val <= min || node.val >= max) 
            return false;
        
        return IsValidBSTHelper(node.left, min, node.val) && 
               IsValidBSTHelper(node.right, node.val, max);
    }
}