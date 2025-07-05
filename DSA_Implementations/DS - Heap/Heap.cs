namespace DSA_Implementations.DS___Heap;

/// <summary>
/// Represents a generic heap data structure that supports both Min-Heap and Max-Heap configurations. 
/// You must specify whether the heap should behave as a Min-Heap or a Max-Heap 
/// by setting the heap type in the constructor.
/// </summary>
/// <typeparam name="T">The type of elements stored in the heap. Must implement IComparable.</typeparam>
public class Heap<T> where T : IComparable<T>
{
    public enum HeapType
    {
        MinHeap,
        MaxHeap
    }

    private readonly List<T> _heap;
    private readonly HeapType _heapType;

    public int Count => _heap.Count; // Exposes the current size of the heap
    public bool IsEmpty => _heap.Count == 0; // Whether the heap is empty

    /// <summary>
    /// Represents a generic heap data structure that supports both Min-Heap and Max-Heap configurations.
    /// </summary>
    /// <param name="heapType">The configuration of the heap (either MinHeap or MaxHeap).</param>
    public Heap(HeapType heapType)
    {
        _heap = new List<T>();
        _heapType = heapType;
    }

    /// <summary>
    /// Inserts a new element into the heap and ensures the heap property is maintained.
    /// </summary>
    /// <param name="value">The value to insert into the heap.</param>
    public void Insert(T value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Value to insert cannot be null.");

        _heap.Add(value);
        HeapifyUp(_heap.Count - 1);
    }

    /// <summary>
    /// Retrieves the top element of the heap (either minimum or maximum) without removing it.
    /// </summary>
    /// <returns>The top element of the heap.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the heap is empty.</exception>
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Heap is empty.");

        return _heap[0];
    }

    /// <summary>
    /// Removes and returns the top element of the heap (either minimum or maximum).
    /// </summary>
    /// <returns>The top element that was removed from the heap.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the heap is empty.</exception>
    public T Extract()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Heap is empty.");

        T rootValue = _heap[0];
        _heap[0] = _heap[^1]; // Move the last element to the root
        _heap.RemoveAt(_heap.Count - 1);
        if (!IsEmpty) HeapifyDown(0);

        return rootValue;
    }

    /// <summary>
    /// Displays all elements of the heap for debugging purposes.
    /// </summary>
    public void DisplayHeap()
    {
        Console.WriteLine("\nHeap Elements: " + string.Join(", ", _heap));
    }

    /// <summary>
    /// Ensures that the heap property is maintained by moving the element at the specified index
    /// up the heap until it is in the correct position relative to its parent.
    /// </summary>
    /// <param name="index">The index of the element to be moved up within the heap.</param>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if ((_heapType == HeapType.MinHeap && _heap[parentIndex].CompareTo(_heap[index]) <= 0) ||
                (_heapType == HeapType.MaxHeap && _heap[parentIndex].CompareTo(_heap[index]) >= 0))
            {
                break;
            }

            (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);
            index = parentIndex;
        }
    }

    /// <summary>
    /// Restores the heap property by moving the element at the specified index down the heap
    /// until it is in the correct position relative to its children.
    /// </summary>
    /// <param name="index">The index of the element to be moved down the heap.</param>
    private void HeapifyDown(int index)
    {
        while (index < _heap.Count)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int targetIndex = index;

            if (_heapType == HeapType.MinHeap)
            {
                if (leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[targetIndex]) < 0)
                    targetIndex = leftChildIndex;

                if (rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[targetIndex]) < 0)
                    targetIndex = rightChildIndex;
            }
            else if (_heapType == HeapType.MaxHeap)
            {
                if (leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[targetIndex]) > 0)
                    targetIndex = leftChildIndex;

                if (rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[targetIndex]) > 0)
                    targetIndex = rightChildIndex;
            }

            if (targetIndex == index) break;

            (_heap[index], _heap[targetIndex]) = (_heap[targetIndex], _heap[index]);
            index = targetIndex;
        }
    }
}