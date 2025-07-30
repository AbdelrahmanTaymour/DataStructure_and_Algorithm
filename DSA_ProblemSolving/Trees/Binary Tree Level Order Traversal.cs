namespace DSA_ProblemSolving.Trees;

/// <summary>
/// Leetcode Problem: Binary Tree Level Order Traversal  
/// - https://leetcode.com/problems/binary-tree-level-order-traversal/
/// 
/// Problem Statement:
/// Given the root of a binary tree, return the level order traversal of its nodes' values.
/// (i.e., from left to right, level by level).
///
/// Example:
/// Input: 
///     3
///    / \
///   9  20
///      / \
///     15  7
///
/// Output: [[3], [9, 20], [15, 7]]
///
/// Approach:
/// - Use a queue to perform Breadth-First Search (BFS).
/// - At each level, dequeue all nodes, record their values, and enqueue their children.
/// - Repeat until the queue is empty.
///
/// Time Complexity: O(n), where n is the number of nodes in the tree.
/// Space Complexity: O(n) for the result list and the queue.
/// </summary>
public class Binary_Tree_Level_Order_Traversal
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        // Final result list containing values level by level
        IList<IList<int>> result = new List<IList<int>>();

        // Queue for BFS traversal
        var queue = new Queue<TreeNode>();

        // Start with the root node
        if (root != null)
            queue.Enqueue(root);

        // Continue until all levels are processed
        while (queue.Count > 0)
        {
            var levelNodes = new List<int>();        // Stores current level's values
            int levelSize = queue.Count;             // Number of nodes at current level

            for (int i = 0; i < levelSize; i++)
            {
                var current = queue.Dequeue();
                levelNodes.Add(current.val);         // Add current node's value

                // Enqueue child nodes for the next level
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
            }

            // Add current level's values to the result
            result.Add(levelNodes);
        }

        return result;
    }
}
