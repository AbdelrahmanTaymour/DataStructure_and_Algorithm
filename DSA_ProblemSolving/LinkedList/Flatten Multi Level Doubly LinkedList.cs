namespace DSA_ProblemSolving.LinkedList;

public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}

/// <summary>
/// Leetcode Problem: Flatten a Multilevel Doubly Linked List  
/// - https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/
///
/// Problem Statement:
/// You are given a doubly linked list, which in addition to the next and previous pointers, 
/// may have a child pointer, which may point to a separate doubly linked list.
/// These child lists may have one or more children of their own, and so on.
///
/// The goal is to flatten the list so that all the nodes appear in a single-level doubly linked list. 
/// The nodes should be placed in depth-first order.
///
/// Example:
/// Input:
/// 1---2---3---4---5---6--NULL
///         |
///         7---8---9---10--NULL
///             |
///             11--12--NULL
///
/// Output:
/// 1-2-3-7-8-11-12-9-10-4-5-6
///
/// Approach:
/// - Traverse the list node by node.
/// - If a node has a child:
///     - Store the next node temporarily.
///     - Recursively flatten the child list and set it as the current node’s next.
///     - Update the (prev) of the child’s head.
///     - Set the child to null.
///     - Traverse to the end of the newly attached child list.
///     - Reconnect the stored next node after the flattened child list.
///
/// Time Complexity: O(N), where N is the total number of nodes in the list (including all children).
/// Space Complexity: O(N) in the worst case due to recursion stack.
/// </summary>
public class Flatten_Multi_Level_Doubly_LinkedList
{
    public Node Flatten(Node head)
    {
        if (head == null) return head;

        Node cur = head;
        while (cur != null)
        {
            if (cur.child != null)
            {
                // Store the current node's next pointer so we can reconnect it later
                Node next = cur.next;

                // Recursively flatten the child list and attach it to current node
                cur.next = Flatten(cur.child);

                // Update the 'prev' pointer of the new next node (which was a child)
                cur.next.prev = cur;

                // Clear the child pointer as it's now flattened
                cur.child = null;

                // Move to the tail of the flattened child list
                while (cur.next != null)
                    cur = cur.next;

                // Reconnect the original next node to the tail of the flattened child
                if (next != null)
                {
                    cur.next = next;
                    next.prev = cur;
                }
            }

            // Move to the next node
            cur = cur.next;
        }

        return head;
    }
}