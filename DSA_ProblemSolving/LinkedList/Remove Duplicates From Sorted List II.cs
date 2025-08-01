namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Leetcode Problem: Remove Duplicates from Sorted List II  
/// - https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
///
/// Problem Statement:
/// Given the head of a sorted linked list, delete all nodes that have duplicate numbers,
/// leaving only distinct numbers from the original list.
/// 
/// Example:
/// Input: 1 → 2 → 3 → 3 → 4 → 4 → 5  
/// Output: 1 → 2 → 5
///
/// Input: 1 → 1 → 1 → 2 → 3  
/// Output: 2 → 3
///
/// Approach:
/// - Use a dummy node to simplify edge cases (like removing head node).
/// - Use two pointers:
///     - `p1`: Tracks the last confirmed distinct node.
///     - `p2`: Scans ahead to check for duplicates.
/// - If duplicates are found (`p2.val == p2.next.val`), skip all nodes with that value.
/// - Otherwise, move `p1` forward.
///
/// Time Complexity: O(n) — Each node is visited once.
/// Space Complexity: O(1) — In-place modification without extra memory.
/// </summary>
public class Remove_Duplicates_From_Sorted_List_II
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        // Dummy node before the actual head to simplify deletions
        var dummy = new ListNode(0, head);
        var p1 = dummy;

        while (p1.next != null)
        {
            var p2 = p1.next;

            // Detect the start of a duplicate sequence
            if (p2.next != null && p2.val == p2.next.val)
            {
                // Move p2 to the last duplicate node
                while (p2.next != null && p2.val == p2.next.val)
                {
                    p2 = p2.next;
                }

                // Skip the entire duplicate sequence
                p1.next = p2.next;
            }
            else
            {
                // No duplicates, move p1 to next
                p1 = p1.next;
            }
        }

        return dummy.next;
    }
}