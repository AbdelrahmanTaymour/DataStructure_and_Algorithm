namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Reverses a singly linked list.
/// 
/// Example:
/// Input: 1 → 2 → 3 → 4 → 5  
/// Output: 5 → 4 → 3 → 2 → 1
///
/// Approach:
/// - Use three pointers:
///     - `current` to track the current node in iteration,
///     - `prev` to track the new previous node,
///     - `next` to temporarily store the next node.
/// - Iterate through the list, reverse the link direction for each node.
/// - At the end, `prev` will point to the new head of the reversed list.
///
/// Time Complexity: O(n) — Each node is visited once.
/// Space Complexity: O(1) — In-place reversal using constant space.
/// </summary>
public class ReverseLinkedList
{
    public ListNode<int> Reverse(ListNode<int> head)
    {
        ListNode<int> current = head;
        ListNode<int> prev = null;

        // Iterate through the list and reverse the links
        while (current != null)
        {
            ListNode<int> next = current.next; // Store the next node
            current.next = prev;               // Reverse the current node's pointer
            prev = current;                    // Move prev to current
            current = next;                    // Move to the next node
        }

        // At the end, prev is the new head
        return prev;
    }
}

public class ListNode<T>
{
    public T val { get; set; }
    public ListNode<T> next { get; set; }

    public ListNode(T val , ListNode<T> next = null)
    {
        this.val = val;
        this.next = next;
    }
}