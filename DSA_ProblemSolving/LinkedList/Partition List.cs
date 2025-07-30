namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Leetcode Problem: Partition List  
/// - https://leetcode.com/problems/partition-list/
///
/// Problem Statement:
/// Given the head of a linked list and an integer `x`, partition the list so that:
/// - All nodes less than `x` come before nodes greater than or equal to `x`.
/// - The relative order of nodes in each partition should be preserved.
///
/// Example:
/// Input: head = 1 → 4 → 3 → 2 → 5 → 2, x = 3  
/// Output: 1 → 2 → 2 → 4 → 3 → 5
///
/// Approach:
/// - Use two separate linked lists:
///     - One for nodes with values less than `x` (`before` list).
///     - One for nodes with values greater than or equal to `x` (`after` list).
/// - Traverse the original list and add nodes to the corresponding list.
/// - At the end, connect `before` list with the `after` list.
///
/// Time Complexity: O(n) – each node is visited once.
/// Space Complexity: O(1) – only uses pointers, not extra data structures.
/// </summary>
public class Partition_List
{
    public ListNode Partition(ListNode head, int x)
    {
        // Dummy heads to simplify list management
        ListNode beforeHead = new ListNode(0); // List for nodes < x
        ListNode afterHead = new ListNode(0);  // List for nodes >= x

        ListNode before = beforeHead;
        ListNode after = afterHead;

        // Traverse the original list
        while (head != null)
        {
            if (head.val < x)
            {
                // Add to 'before' list
                before.next = head;
                before = before.next;
            }
            else
            {
                // Add to 'after' list
                after.next = head;
                after = after.next;
            }

            head = head.next;
        }

        // Terminate the 'after' list to avoid potential cycles
        after.next = null;

        // Connect 'before' list to the start of 'after' list
        before.next = afterHead.next;

        // Return the head of the new partitioned list
        return beforeHead.next;
    }
}
