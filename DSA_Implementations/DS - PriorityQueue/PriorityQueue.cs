namespace DSA_Implementations.DS___PriorityQueue;

public class PriorityQueueNode<T>
{
    public T Name { get; set; }
    public int Priority { get; set; }

    public PriorityQueueNode(T name, int priority)
    {
        Name = name;
        Priority = priority;
    }
}


/// <summary>
/// Represents a generic priority queue implemented using a Min-Heap. 
/// The implementation ensures that the element with the smallest priority is always at the front of the queue.
/// </summary>
/// <typeparam name="T">The type of the value stored in the priority queue nodes.</typeparam>
public class PriorityQueue<T>
{
    private List<PriorityQueueNode<T>> heap = new List<PriorityQueueNode<T>>();

    // Insert a new element with a priority
    public void Insert(T name, int priority)
    {
        var node = new PriorityQueueNode<T>(name, priority);
        heap.Add(node);
        HeapifyUp(heap.Count - 1);
    }

    // Extract the element with the minimum priority
    public PriorityQueueNode<T> ExtractMin()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        var minNode = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        HeapifyDown(0);

        return minNode;
    }

    // Peek at the element with the minimum priority without removing it
    public PriorityQueueNode<T> Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Priority Queue is empty.");
        }

        return heap[0];
    }

    // Helper method to restore the heap property by bubbling up
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (heap[index].Priority >= heap[parentIndex].Priority) break;

            (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
            index = parentIndex;
        }
    }

    // Helper method to restore the heap property by bubbling down
    private void HeapifyDown(int index)
    {
        while (index < heap.Count)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallestIndex = index;

            if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority < heap[smallestIndex].Priority)
                smallestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority < heap[smallestIndex].Priority)
                smallestIndex = rightChildIndex;

            if (smallestIndex == index) break;

            (heap[index], heap[smallestIndex]) = (heap[smallestIndex], heap[index]);
            index = smallestIndex;
        }
    }
}