namespace DSA_ProblemSolving.Recursion;

public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}

public class Flatten_Multi_Level_Doubly_LinkedList
{
    /// <summary>
    /// Leetcode Problem: Flatten a Multilevel Doubly Linked List  
    /// - https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/
    ///
    /// Problem Statement:
    /// Given a doubly linked list where nodes may contain a child pointer to another doubly linked list,
    /// flatten it so that all nodes appear in a single-level doubly linked list in depth-first order.
    ///
    /// This implementation uses DFS recursion to collect all nodes in order, 
    /// and then rebuilds the flattened list by connecting the nodes.
    ///
    /// Approach:
    /// - Traverse the list recursively in a DFS manner.
    /// - First visit the current node, then its child, then its next node.
    /// - Store visited nodes in a list.
    /// - Reconnect all nodes from the list using prev and next pointers.
    ///
    /// Time Complexity: O(N), where N is the total number of nodes.
    /// Space Complexity: O(N) for storing nodes in a list.
    /// </summary>
    
    // Holds the nodes in depth-first traversal order
    private List<Node> list;
    
    public Node Flatten(Node head)
    {
        // Initialize the list to hold flattened nodes in DFS order
        list = new();

        // Start the recursive DFS flattening
        FlattenRecursive(head);

        // Reconnect the flattened list by updating next and prev pointers
        for (int i = 1; i < list.Count; i++)
        {
            Node prev = list[i - 1];
            Node current = list[i];

            prev.next = current;
            current.prev = prev;
        }

        return head;
    }

    /// <summary>
    /// Recursively visits nodes in DFS order:
    /// current node → child → next
    /// </summary>
    private void FlattenRecursive(Node? node)
    {
        if (node == null)
            return;

        // Add current node to the list
        list.Add(node);

        // Recursively flatten the child and next
        FlattenRecursive(node.child);
        FlattenRecursive(node.next);

        // Remove child link after flattening
        node.child = null;
    }
}