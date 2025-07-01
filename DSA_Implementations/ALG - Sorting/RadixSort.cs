namespace DSA_Implementations.ALG___Sorting;

/// <summary>
/// Implements the Radix Sort algorithm, which sorts integers by processing each digit position,
/// starting from the least significant digit to the most significant digit.
/// </summary>
public class RadixSort
{
    /// <summary>
    /// Sorts an array using the Radix Sort algorithm.
    /// Time Complexity: O(d * (n + k)) where d is the number of digits, n is the number of elements,
    /// and k is the range of values for each digit (10 for decimal)
    /// Space Complexity: O(n + k)
    /// </summary>
    /// <param name="arrayToSort">Array to be sorted</param>
    /// <param name="arrayLength">Length of the array</param>
    /// <remarks>
    /// Features:
    /// - Non-comparative sorting algorithm
    /// - Stable sort
    /// - Works best with fixed-length integers
    /// - Can be faster than O(n log n) algorithms for integers
    /// Limitations:
    /// - Only works with non-negative integers
    /// - Requires extra space
    /// - Performance depends on number of digits
    /// </remarks>
    public static void Sort(int[] arrayToSort, int arrayLength)
    {
        // Find the maximum number to know number of digits
        int maxValue = FindMaxValue(arrayToSort, arrayLength);

        // Do counting sort for every digit
        // exp is 10^i where i is the current digit position
        for (int exp = 1; maxValue / exp > 0; exp *= 10)
        {
            CountingSortByDigit(arrayToSort, arrayLength, exp);
        }
    }

    /// <summary>
    /// Finds the maximum value in the array to determine the number of digits.
    /// </summary>
    /// <returns>The maximum value in the array</returns>
    private static int FindMaxValue(int[] array, int length)
    {
        int max = array[0];
        for (int i = 1; i < length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    /// <summary>
    /// Performs counting sort on a specific digit position.
    /// </summary>
    /// <param name="array">Array to be sorted</param>
    /// <param name="length">Length of the array</param>
    /// <param name="digitPosition">Current digit position (1, 10, 100, etc.)</param>
    private static void CountingSortByDigit(int[] array, int length, int digitPosition)
    {
        int[] output = new int[length];
        int[] count = new int[10]; // 10 possible digits (0-9)

        // Initialize a count array
        Array.Fill(count, 0);

        // Store count of occurrences of the current digit
        for (int i = 0; i < length; i++)
        {
            int digit = (array[i] / digitPosition) % 10;
            count[digit]++;
        }

        // Change count[i] to contain actual position of digit in output
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array
        for (int i = length - 1; i >= 0; i--)
        {
            int digit = (array[i] / digitPosition) % 10;
            output[count[digit] - 1] = array[i];
            count[digit]--;
        }

        // Copy the output array to the input array
        for (int i = 0; i < length; i++)
        {
            array[i] = output[i];
        }
    }
}