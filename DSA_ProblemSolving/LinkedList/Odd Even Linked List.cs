namespace DSA_ProblemSolving.LinkedList;

/// <summary>
/// Leetcode Problem: Odd Even Linked List  
/// - https://leetcode.com/problems/odd-even-linked-list/
///
/// Problem Statement:
/// Given the head of a singly linked list, group all the nodes with odd indices together 
/// followed by the nodes with even indices, and return the reordered list.
/// Note: The node index starts from 1 (i.e., the head is index 1).
///
/// Example:
/// Input: 1 -> 2 -> 3 -> 4 -> 5  
/// Output: 1 -> 3 -> 5 -> 2 -> 4
///
/// Approach:
/// - Use two dummy heads: one for odd-indexed nodes, one for even-indexed nodes.
/// - Traverse the list while maintaining an index counter.
/// - Append nodes to the corresponding odd or even list.
/// - At the end, connect the odd list to the even list.
///
/// Time Complexity: O(n) – Every node is visited once.
/// Space Complexity: O(1) – No extra space is used other than a few pointers.
/// </summary>
public class OddEven_LinkedList
{
    public ListNode OddEvenList(ListNode head)
    {
        // Dummy heads to simplify odd/even list building
        ListNode oddHead = new ListNode(0);
        ListNode evenHead = new ListNode(0);

        // Pointers to track the end of each sublist
        ListNode odd = oddHead, even = evenHead;

        int index = 1; // 1-based index
        while (head != null)
        {
            if (index % 2 == 0)
            {
                // Even-indexed node
                even.next = head;
                even = even.next;
            }
            else
            {
                // Odd-indexed node
                odd.next = head;
                odd = odd.next;
            }

            head = head.next;
            index++;
        }

        // End the even list to avoid a cycle
        even.next = null;

        // Connect the odd list to the even list
        odd.next = evenHead.next;

        return oddHead.next;
    }
}
