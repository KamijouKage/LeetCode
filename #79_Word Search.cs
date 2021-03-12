using System;

namespace P79
{
    class Program
    {
        static void Main(string[] arags)
        {
        }
    }

    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            bool result = false;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    Search(board, word, 0, j, i, ref result);
                }
            }
            return result;
        }

        private void Search(char[][] board, string word, int index, int x, int y, ref bool result)
        {
            if (result || x < 0 || x >= board[0].Length || y < 0 || y >= board.Length || board[y][x] != word[index])
            {
                return;
            }
            if (index == word.Length - 1)
            {
                result = true;
                return;
            }
            char temp = board[y][x];
            board[y][x] = '.';
            Search(board, word, index + 1, x, y - 1, ref result);
            Search(board, word, index + 1, x, y + 1, ref result);
            Search(board, word, index + 1, x - 1, y, ref result);
            Search(board, word, index + 1, x + 1, y, ref result);
            board[y][x] = temp;
        }
    }
}