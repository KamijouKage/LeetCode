using System;

namespace P34
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }
            int l = 0;
            int r = nums.Length - 1;
            int first = -1;
            int last = -1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                first = nums[mid] == target ? mid : first;
                r = nums[mid] >= target ? mid - 1 : r;
                l = nums[mid] < target ? mid + 1 : l;
            }
            if (first == -1)
            {
                return new int[] { -1, -1 };
            }
            l = first;
            r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                last = nums[mid] == target ? mid : last;
                r = nums[mid] > target ? mid - 1 : r;
                l = nums[mid] <= target ? mid + 1 : l;
            }
            return new int[] { first, last };
        }
    }
}