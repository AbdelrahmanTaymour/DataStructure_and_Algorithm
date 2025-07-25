namespace DSA_ProblemSolving.Trees;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

// Leetcode problem: Maximum Depth of Binary Tree
// - https://leetcode.com/problems/maximum-depth-of-binary-tree/

public class Maximum_Depth_of_Binary_Tree
{
    public int MaxDepth(TreeNode root) {
        return recursive(root, 0);
    }

    private int recursive(TreeNode node, int count){
        if(node == null) return count;
        count++;
        return Math.Max(recursive(node.left, count), recursive(node.right, count));
    }
}