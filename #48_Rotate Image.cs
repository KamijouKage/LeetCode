using System;

namespace P48
{
    class Program
    {
        static void Main(String[] arags)
        {

        }
    }

    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    swap(ref matrix[i][j], ref matrix[j][i]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    swap(ref matrix[i][j], ref matrix[i][n - 1 - j]);
                }
            }
        }

        private void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}