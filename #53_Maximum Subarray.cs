using System;

namespace P53
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1 };
            Console.WriteLine(solution.MaxSubArray(nums));
        }
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = Math.Max(nums[i], nums[i] + nums[i - 1]);
                maxSum = Math.Max(maxSum, nums[i]);
            }
            return maxSum;
        }
    }
}