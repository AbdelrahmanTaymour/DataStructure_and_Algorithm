namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Leetcode Problem: Reverse Linked List II  
/// - https://leetcode.com/problems/reverse-linked-list-ii/
///
/// Problem Statement:
/// Reverse a sublist of a singly linked list from position `left` to `right` (1-indexed), and return the modified list.
///
/// Example:
/// Input: head = 1 → 2 → 3 → 4 → 5, left = 2, right = 4  
/// Output: 1 → 4 → 3 → 2 → 5
///
/// Approach:
/// - Use a dummy node to handle edge cases (like reversing from the head).
/// - Traverse to the node just before the start of the sublist (`left - 1`) and call it `prev`.
/// - Reverse the sublist between `left` and `right` using in-place pointer manipulation.
/// - Do this by repeatedly taking the next node in the sublist and inserting it right after `prev`.
///
/// Time Complexity: O(n) — Traverses the list once.
/// Space Complexity: O(1) — Reverses the sublist in-place.
/// </summary>
public class Reverse_Linked_List_II
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || left == right)
            return head;

        // Dummy node simplifies edge case handling
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;

        // Move `prev` to the node before the reversal segment
        for (int i = 1; i < left; i++)
            prev = prev.next;

        // `curr` points to the first node in the segment to be reversed
        ListNode curr = prev.next;

        // Reverse the sublist using head insertion technique
        for (int i = 0; i < right - left; i++)
        {
            ListNode next = curr.next;       // Take the node after `curr`
            curr.next = next.next;           // Remove `next` from its current spot
            next.next = prev.next;           // Insert `next` after `prev`
            prev.next = next;                // Update `prev` to point to the newly moved node
        }

        return dummy.next;
    }
}