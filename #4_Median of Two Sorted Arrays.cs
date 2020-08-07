using System;

namespace P4
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // int[] nums1 = new int[] {3,5,9,10,11,16};
            // int[] nums2 = new int[] {4,6,8,15};

            // int[] nums1 = new int[] {1,2,3,6,7};
            // int[] nums2 = new int[] {4,5,8,9,10};

            // int[] nums1 = new int[] {1,2};
            // int[] nums2 = new int[] {3,4};

            // int[] nums1 = new int[] {3,4};
            // int[] nums2 = new int[] {1,2};

            int[] nums1 = new int[] { 1, 3 };
            int[] nums2 = new int[] { 2 };

            Console.Write(solution.FindMedianSortedArrays(nums1, nums2));
        }
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] a;
            int[] b;
            if (nums1.Length <= nums2.Length)
            {
                a = nums1;
                b = nums2;
            }
            else
            {
                a = nums2;
                b = nums1;
            }
            int mergeLeftLength = (a.Length + b.Length) / 2;
            int aLeftLength = a.Length / 2;
            int bLeftLength = mergeLeftLength - aLeftLength;
            int searchLeft = 1;
            int searchRight = a.Length;
            while (true)
            {
                int al = (aLeftLength - 1 >= 0) ? a[aLeftLength - 1] : int.MinValue;
                int ar = (aLeftLength != a.Length) ? a[aLeftLength] : int.MaxValue;
                int bl = (bLeftLength - 1 >= 0) ? b[bLeftLength - 1] : int.MinValue;
                int br = (bLeftLength != b.Length) ? b[bLeftLength] : int.MaxValue;
                if (al <= br && ar >= bl)
                {
                    return ((a.Length + b.Length) % 2 == 0) ? (double)(Math.Max(al, bl) + Math.Min(ar, br)) / 2 : Math.Min(ar, br);
                }
                if (al > br)
                {
                    searchRight = aLeftLength - 1;
                }
                else
                {
                    searchLeft = aLeftLength + 1;
                }
                aLeftLength = (searchLeft + searchRight) / 2;
                bLeftLength = mergeLeftLength - aLeftLength;
            }
        }
    }
}