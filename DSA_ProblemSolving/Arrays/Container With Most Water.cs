namespace DSA_ProblemSolving.Arrays;


// // LeetCode Problem: Container With Most Water - https://leetcode.com/problems/container-with-most-water/

public class ContainerWithMostWater
{
    private static int min(int val1, int val2)
    {
        return val1 <= val2 ? val1 : val2;
    }
    
    // Finds the maximum amount of water a container can store between two heights in an array.
    // The approach uses the two-pointer technique to find the maximum area efficiently.
    //
    // Time Complexity: O(N), where N is the number of elements in the height array. 
    // The loop runs at most N iterations because the `left` and `right` pointers move towards each other,
    // processing each element only once.
    // 
    // Space Complexity: O(1). 
    // The algorithm uses a constant amount of extra space irrespective of the input size.
    public static int MaxArea(int[] height)
    {
        // maxArea stores the maximum area found so far.
        int maxArea = 0;

        // Set two pointers: 
        // 'left' starts from the beginning of the array, 
        // 'right' starts from the end of the array.
        int left = 0, right = height.Length - 1;
        
        // Continue iterating as long as the pointers do not overlap.
        while (left < right)
        {
            // Calculate the current area:
            // The height is determined by the shorter of the two lines at 'left' and 'right'.
            // The width is the distance between 'left' and 'right'.
            int currentArea = Math.Min(height[right], height[left]) * (right - left);
            
            // Update the maximum area if the current area is larger.
            maxArea = System.Math.Max(currentArea, maxArea);

            // Move the pointer corresponding to the shorter line inward:
            // This is because the shorter line is the limiting factor for the container's height,
            // and we want to explore potentially larger containers by changing the line.
            if (height[left] <= height[right])
            {
                // If the left pointer points to the shorter line, move it to the right.
                left++;
            }
            else
            {
                // Otherwise, move the right pointer to the left.
                right--;
            }
        }

        // Return the maximum area found during all iterations.
        return maxArea;
    }

}