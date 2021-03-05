using System;

namespace P42
{
    class Program
    {
        static void Main(string[] arags)
        {

        }
    }

    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height.Length == 0)
            {
                return 0;
            }
            int water = 0;
            int l = 0;
            int r = height.Length - 1;
            int maxL = height[l];
            int maxR = height[r];
            while (l < r)
            {
                if (maxL < maxR)
                {
                    water += (maxL - height[l]);
                    maxL = Math.Max(maxL, height[++l]);
                }
                else
                {
                    water += (maxR - height[r]);
                    maxR = Math.Max(maxR, height[--r]);
                }
            }
            return water;
        }

        public int DP(int[] height)
        {
            int water = 0;
            int n = height.Length;
            if (n == 0)
            {
                return 0;
            }
            int[] leftMax = new int[n];
            int[] rightMax = new int[n];
            leftMax[0] = height[0];
            rightMax[n - 1] = height[n - 1];
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            }
            for (int i = n - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }
            for (int i = 0; i < n; i++)
            {
                int min = Math.Min(leftMax[i], rightMax[i]);
                if (min > height[i])
                {
                    water += min - height[i];
                }
            }
            return water;
        }
    }
}