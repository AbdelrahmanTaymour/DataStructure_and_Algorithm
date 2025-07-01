namespace DSA_ProblemSolving.Arrays;

/// <summary>
/// LeetCode Problem: Candy - https://leetcode.com/problems/candy/
/// Calculates minimum candies needed to distribute to children based on their ratings
/// while satisfying the conditions that children with higher ratings get more candies
/// than their neighbors.
/// Time: O(n) | Space: O(n)
/// </summary>

public class Candy
{
    public static int Solution(int[] ratings) {
        int ratingsLength = ratings.Length;
        int[] candies = new int[ratingsLength];

        // First pass: Left to Right
        // Ensure each child has more candies than the child to their left
        // if they have a higher rating
        for (int i = 0; i < ratingsLength; i++) {
            if (i == 0)
                // The first child always gets 1 candy initially
                candies[i] = 1; 
            else if (ratings[i] > ratings[i - 1])
                // If current child has higher rating than left neighbor
                // give them one more candy than the left neighbor
                candies[i] = candies[i - 1] + 1;
            else
                // If the rating is less or equal, give minimum 1 candy
                candies[i] = 1;
        }

        // Second pass: Right to Left
        // Ensure each child has more candies than the child to their right
        // if they have a higher rating
        for (int i = ratingsLength - 2; i >= 0; i--)
            if(ratings[i] > ratings[i + 1])
                // Take maximum between current candies and
                // (right neighbor's candies + 1) to satisfy both conditions
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);

        // Calculate total candies needed
        int total = 0;
        foreach(int c in candies)
            total += c;

        return total;
    }
}