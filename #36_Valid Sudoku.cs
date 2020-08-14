using System;
using System.Collections.Generic;

namespace P36
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[][]
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };
            Solution solution = new Solution();
            solution.IsValidSudoku(board);
        }
    }

    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            List<char> row = new List<char>();
            List<char>[] col = new List<char>[9];
            List<char>[,] box = new List<char>[3, 3];
            for (int i = 0; i < 9; i++)
            {
                col[i] = new List<char>();
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box[i, j] = new List<char>();
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        continue;
                    }
                    if (row.Contains(board[i][j]) || col[j].Contains(board[i][j]) || box[i / 3, j / 3].Contains(board[i][j]))
                    {
                        return false;
                    }
                    row.Add(board[i][j]);
                    col[j].Add(board[i][j]);
                    box[i / 3, j / 3].Add(board[i][j]);
                }
                row.Clear();
            }
            return true;
        }
    }
}