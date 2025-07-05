namespace DSA_Implementations.ALG___Sorting;

public class HeapSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Build a Max-Heap from the input array.
        // Start from the last non-leaf node, calculated using the formula (n / 2 - 1),
        // as all nodes beyond this index are leaf nodes and already satisfy the heap property.
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            // Perform heapify from the last non-leaf node down to the root
            HeapifyDown(arr, n, i);
        }

        // Step 2: Perform the sorting
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (largest element) with the last element of the current heap
            (arr[0], arr[i]) = (arr[i], arr[0]);

            // Call heapify on the reduced heap to restore the heap property
            HeapifyDown(arr, i, 0);
        }
    }
    
    private static void HeapifyDown(int[] arr, int n, int index)
    {
        while (index < n)
        {
            // Identify the indices of the left and right children of the current node
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;

            // Assume the current element is the largest
            int maxIndex = index;

            // Check if the left child exists and is greater than the current largest element
            if (leftChildIndex < n && arr[leftChildIndex] > arr[maxIndex])
            {
                maxIndex = leftChildIndex;
            }

            // Check if the right child exists and is greater than the current largest element
            if (rightChildIndex < n && arr[rightChildIndex] > arr[maxIndex])
            {
                maxIndex = rightChildIndex;
            }

            // If the largest element is the current node, stop the process
            if (maxIndex == index) break;

            // Swap the current node with the largest child
            (arr[index], arr[maxIndex]) = (arr[maxIndex], arr[index]);

            // Move to the next node (the largest child's index) and continue the process
            index = maxIndex;
        }
    }
}