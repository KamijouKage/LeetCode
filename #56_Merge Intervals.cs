using System;
using System.Collections;
using System.Collections.Generic;

namespace P56
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[][] intervals = new int[][] { new int[] { 1, 9 }, new int[] { 2, 5 }, new int[] { 19, 20 }, new int[] { 10, 11 }, new int[] { 12, 20 }, new int[] { 0, 3 } };
            solution.Merge(intervals);
        }
    }

    public class Solution
    {
        public class MyComparer : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                int[] a = x as int[];
                int[] b = y as int[];
                return a[0].CompareTo(b[0]);
            }
        }

        public int[][] Merge(int[][] intervals)
        {
            List<int[]> merged = new List<int[]>();
            Array.Sort(intervals, new MyComparer());
            for (int i = 0; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];
                int j;
                for (j = i; j < intervals.Length; j++)
                {
                    if (end >= intervals[j][0])
                    {
                        end = Math.Max(end, intervals[j][1]);
                    }
                    else
                    {
                        break;
                    }
                }
                merged.Add(new int[] { start, end });
                i = j - 1;
            }
            return merged.ToArray();
        }
    }
}