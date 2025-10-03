namespace DSA_ProblemSolving.Arrays;

// Leetcode Problem: Water Bottles  
// - https://leetcode.com/problems/water-bottles/
// Problem Statement:
// There are `numBottles` water bottles that are initially full of water. You can exchange `numExchange`
// empty water bottles from the market with one full water bottle.
// The operation of drinking a full water bottle turns it into an empty bottle.
// Given the two integers `numBottles` and `numExchange`, return the maximum number of water bottles
// you can drink.
// 
// Example 1:
// Input: numBottles = 9, numExchange = 3
// Output: 13
// Explanation: You can exchange 3 empty bottles to get 1 full water bottle.
// Number of water bottles you can drink: 9 + 3 + 1 = 13.
// 
// Example 2:
// Input: numBottles = 15, numExchange = 4
// Output: 19
// Explanation: You can exchange 4 empty bottles to get 1 full water bottle.
// Number of water bottles you can drink: 15 + 3 + 1 = 19.
// 
// Example 3:
// Input: numBottles = 5, numExchange = 5
// Output: 6
// Explanation: You can exchange 5 empty bottles to get 1 full water bottle.
// Number of water bottles you can drink: 5 + 1 = 6.
// 
// Constraints:
// - 1 ≤ numBottles ≤ 100
// - 2 ≤ numExchange ≤ 100
public class WaterBottles
{
    // Approach:
    // - Start by drinking all initial full bottles and count them as `totalDrank`.
    // - Track the number of empty bottles accumulated.
    // - While there are enough empty bottles to exchange (emptyBottles >= numExchange):
    //   1. Calculate how many full bottles can be obtained by exchanging: exchangedBottles = emptyBottles / numExchange
    //   2. Add the exchanged bottles to totalDrank
    //   3. Update emptyBottles: remaining empty bottles (emptyBottles % numExchange) plus the newly drunk bottles (exchangedBottles)
    // - Continue until there are not enough empty bottles to exchange.
    // - Return the total number of bottles drunk.

    // Algorithm Analysis:
    // - Time Complexity: O(log n), where `n` is numBottles.
    //   The number of empty bottles decreases approximately by a factor of numExchange in each iteration.
    // - Space Complexity: O(1), as only a constant amount of extra space is used.
    public static int NumWaterBottles(int numBottles, int numExchange) 
    {
        int totalDrank = numBottles;
        int emptyBottles = numBottles;

        while (emptyBottles >= numExchange)
        {
            int exchangedBottles = emptyBottles / numExchange;
            totalDrank += exchangedBottles;
            emptyBottles = (emptyBottles % numExchange) + exchangedBottles;
        }

        return totalDrank;
    }

}