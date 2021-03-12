using System;
using System.Collections.Generic;

namespace P78
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[] nums = new int[] { 1, 2, 3 };
            solution.Subsets(nums);
        }
    }

    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                int resultCount = result.Count;
                for (int j = 0; j < resultCount; j++)
                {
                    List<int> subset = new List<int>();
                    subset.AddRange(result[j]);
                    subset.Add(nums[i]);
                    result.Add(subset);
                }
            }
            return result;
        }
    }
}