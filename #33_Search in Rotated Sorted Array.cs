using System;

namespace P33
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;
            Console.Write(solution.Search(nums, target));
        }
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }
            int l = 0;
            int r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[r])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            if (target > nums[nums.Length - 1])
            {
                r = l - 1;
                l = 0;
            }
            else
            {
                r = nums.Length - 1;
            }
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return -1;
        }
    }
}