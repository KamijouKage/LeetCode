using System;

namespace P11
{
    class Program
    {
        static void Main(string[] atgs)
        {
            Solution solution = new Solution();
            int[] m = new int[] { 2, 3, 4, 5, 18, 17, 6 };
            Console.Write(solution.MaxArea(m));
        }
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int max = 0;
            int i = 0;
            int j = height.Length - 1;
            while (i != j)
            {
                max = Math.Max(max, (j - i) * Math.Min(height[i], height[j]));
                if (height[i] < height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return max;
        }
    }
}