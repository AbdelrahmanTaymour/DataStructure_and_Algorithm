namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Leetcode Problem: Remove Nth Node From End of List  
/// - https://leetcode.com/problems/remove-nth-node-from-end-of-list/
///
/// Problem Statement:
/// Given the head of a linked list, remove the nth node from the end of the list and return its head.
///
/// Example:
/// Input: 1 → 2 → 3 → 4 → 5, n = 2  
/// Output: 1 → 2 → 3 → 5
///
/// Approach (Two-Pointer Technique):
/// - Use a dummy node before the head to simplify edge cases (like removing the first node).
/// - Use two pointers `p1` and `p2`, both starting from the dummy node.
/// - Advance `p2` by `n + 1` steps to create a gap of `n` nodes between `p1` and `p2`.
/// - Move both pointers one step at a time until `p2` reaches the end.
/// - Now, `p1` is just before the node to be removed. Adjust the `next` pointer to skip it.
///
/// Time Complexity: O(n) — Single pass through the list.
/// Space Complexity: O(1) — No extra space used.
/// </summary>
public class Remove_Nth_Node_From_End
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        // Dummy node to handle edge cases like removing the head
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode p1 = dummy, p2 = dummy;

        // Move p2 ahead by n + 1 steps to create a gap of n between p1 and p2
        for (int i = 0; i <= n; i++)
            p2 = p2.next;

        // Move both pointers until p2 reaches the end
        while (p2 != null)
        {
            p1 = p1.next;
            p2 = p2.next;
        }

        // p1 is now just before the target node; remove it by skipping
        p1.next = p1.next.next;

        return dummy.next;
    }
}
