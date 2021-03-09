using System;

namespace P55
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 2, 3, 0, 1, 4 };
            int[] nums2 = new int[] { 3, 2, 1, 0, 4 };
            Console.WriteLine(solution.CanJump(nums1));
        }
    }

    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            int maxIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxIndex)
                {
                    return false;
                }
                maxIndex = Math.Max(maxIndex, i + nums[i]);
            }
            return true;
        }
    }
}