namespace DSA_ProblemSolving.Arrays;

// https://leetcode.com/problems/water-bottles-ii/
// 
// Problem Statement:
// You are given two integers `numBottles` and `numExchange`.
// `numBottles` represents the number of full water bottles that you initially have. In one operation, you can perform one of the following:
// - Drink any number of full water bottles turning them into empty bottles.
// - Exchange `numExchange` empty bottles with one full water bottle. Then, increase `numExchange` by one.
// Note that you cannot exchange multiple batches of empty bottles for the same value of `numExchange`. 
// For example, if `numExchange == 3` and you have 6 empty bottles, you can only turn 3 of those bottles into one full bottle.
// Return the maximum number of water bottles you can drink.
// 
// Example 1:
// Input: numBottles = 13, numExchange = 6
// Output: 15
// Explanation: The table shows the number of full/empty bottles at each step:
// Step 1: Drink 13 full bottles → 13 empty bottles. Exchange 6 empty for 1 full (numExchange becomes 7) → 7 empty + 1 full.
// Step 2: Drink 1 full bottle → 8 empty bottles. Exchange 7 empty for 1 full (numExchange becomes 8) → 1 empty + 1 full.
// Step 3: Drink 1 full bottle → 2 empty bottles.
// Total drunk: 13 + 1 + 1 = 15.
// 
// Example 2:
// Input: numBottles = 10, numExchange = 3
// Output: 13
public class Water_Bottles_II
{
    // Approach:
    // - This problem can be solved using a mathematical formula derived from the observation that
    //   the exchange cost increases by 1 after each exchange.
    // - If we perform k exchanges, the total cost is: numExchange + (numExchange+1) + ... + (numExchange+k-1)
    //   which equals k*numExchange + k*(k-1)/2.
    // - We need to find the maximum k such that k*numExchange + k*(k-1)/2 <= numBottles.
    // - Rearranging: k² + (2*numExchange - 1)k - 2*numBottles <= 0.
    // - Simplifying the coefficient: k² + (2*numExchange - 3)k - 2*numBottles <= 0 (after adjusting for the formula).
    // - Using the quadratic formula to solve for k: k = (-b + √(b² - 4ac)) / 2a.
    // - The maximum number of bottles drunk is: numBottles (initial) + k (from exchanges) - 1.

    // Algorithm Analysis:
    // - Time Complexity: O(1), as the solution uses a direct mathematical formula.
    // - Space Complexity: O(1), as only a constant amount of extra space is used.

    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        // Solve quadratic: k² + (2*numExchange - 3)k - 2*numBottles <= 0
        int a = 1;
        int b = 2 * numExchange - 3;
        int c = -2 * numBottles;
        double delta = (double)b * b - 4.0 * a * c;
        int t = (int)Math.Ceiling((-b + Math.Sqrt(delta)) / (2.0 * a));
        return numBottles + t - 1;
    }
}