using System;

namespace P26
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.Write(solution.RemoveDuplicates(nums));

        }
    }

    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int result = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    nums[result++] = nums[i + 1];
                }
            }
            return result;
        }
    }
}