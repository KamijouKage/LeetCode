using System;
using System.Collections.Generic;

namespace P54
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            int[][] matrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            IList<int> result = solution.SpiralOrder(matrix);
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + ", ");
            }
        }
    }

    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> result = new List<int>();
            int left = 0;
            int right = matrix[0].Length - 1;
            int top = 0;
            int bottom = matrix.Length - 1;
            while (left <= right && top <= bottom)
            {
                for (int i = left; i <= right; i++)
                    result.Add(matrix[top][i]);
                for (int i = top + 1; i <= bottom; i++)
                    result.Add(matrix[i][right]);
                if (left < right && top < bottom)
                {
                    for (int i = right - 1; i >= left; i--)
                        result.Add(matrix[bottom][i]);
                    for (int i = bottom - 1; i > top; i--)
                        result.Add(matrix[i][left]);
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            return result;
        }
    }
}