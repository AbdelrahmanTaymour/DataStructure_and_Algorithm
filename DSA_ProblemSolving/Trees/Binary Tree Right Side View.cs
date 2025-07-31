namespace DSA_ProblemSolving.Trees;

// Leetcode Problem: Binary Tree Right Side View  
// - https://leetcode.com/problems/binary-tree-right-side-view/
//
// Problem Statement:
// Given the root of a binary tree, return the values of the nodes you can see
// ordered from top to bottom when looking at the tree from the right side.
//
// Example:
// Input:
//     1      <--------------
//    / \
//   2   3     <--------------
//    \   \
//     5   4    <--------------
//       \
//         6    <--------------
//
// Output: [1, 3, 4, 6]
//
// Approach (Recursive DFS - Right First):
// - Traverse the tree using depth-first search.
// - Always visit the right subtree before the left.
// - For each level, only add the first node encountered (which will be the rightmost node).
//
// Time Complexity: O(n), where n is the number of nodes in the tree.
// Space Complexity: O(h), where h is the height of the tree (due to recursion stack).
// </summary>
public class Binary_Tree_Right_Side_View
{
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> result = new List<int>();
        Recursive(root, result, 1); // Start from level 1
        return result;
    }
    
    private static void Recursive(TreeNode? root, IList<int> list, int level)
    {
        if (root == null)
            return;

        // Add the first node we encounter at this level (which is the rightmost)
        if (level > list.Count)
            list.Add(root.val);

        // Visit right subtree first to prioritize rightmost nodes
        Recursive(root.right, list, level + 1);

        // Then visit left subtree
        Recursive(root.left, list, level + 1);
    }
}
