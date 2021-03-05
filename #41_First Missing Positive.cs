using System;

namespace P41
{
    class Program
    {
        static void Main(string[] arags)
        {

        }
    }

    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 1;
            }
            int numsLength = nums.Length;
            int[] newNums = new int[nums.Length];
            for (int i = 0; i < numsLength; i++)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                {
                    newNums[nums[i] - 1] = nums[i];
                }
            }
            for (int i = 0; i < numsLength; i++)
            {
                if (newNums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return numsLength + 1;
        }
    }
}