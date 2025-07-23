namespace DSA_ProblemSolving.LinkedList;

public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) { 
         val = x; 
         next = null;
    }
}

public class Linked_List_Cycle_II
{
    /// <summary>
    /// Leetcode Problem: Linked List Cycle II  
    /// - https://leetcode.com/problems/linked-list-cycle-ii/
    ///
    /// Problem Statement:
    /// Given the head of a linked list, return the node where the cycle begins. 
    /// If there is no cycle, return null.
    ///
    /// There is a cycle in a linked list if there is some node in the list that can be reached again 
    /// by continuously following the next pointer.
    ///
    /// Approach (Floyd's Tortoise and Hare):
    /// - Step 1: Use two pointers, slow and fast.
    ///     - Move slow one step at a time.
    ///     - Move fast two steps at a time.
    ///     - If there is a cycle, they will eventually meet.
    /// - Step 2: Once a cycle is detected (slow == fast), reset one pointer to head.
    ///     - Move both pointers one step at a time.
    ///     - The point where they meet again is the start of the cycle.
    ///
    /// Key Insight:
    /// - Let’s say the cycle starts at node `C` and the cycle length is `L`.
    /// - When slow and fast meet inside the cycle, moving one pointer from head and the other from the meeting point,
    ///   both will reach the cycle start in the same number of steps.
    ///
    /// Time Complexity: O(N)
    /// Space Complexity: O(1)
    /// </summary>
    /// <param name="head">The head of the linked list</param>
    /// <returns>The node where the cycle begins, or null if no cycle</returns>
    public ListNode DetectCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        // Step 1: Detect if a cycle exists using fast and slow pointers
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            // Cycle detected
            if (fast == slow)
            {
                // Step 2: Find the start of the cycle
                slow = head;

                while (fast != slow)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                // Both pointers meet at the start of the cycle
                return slow;
            }
        }

        // No cycle found
        return null;
    }
}