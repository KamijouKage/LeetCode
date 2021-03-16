using System;
using System.Collections.Generic;

namespace P105
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }
            return Construct(preorder, inorder, map, 0, 0, preorder.Length - 1);
        }

        private TreeNode Construct(int[] preorder, int[] inorder, Dictionary<int, int> map, int rootIndexPre, int left, int right)
        {
            if (rootIndexPre >= preorder.Length || left > right)
            {
                return null;
            }
            TreeNode root = new TreeNode(preorder[rootIndexPre]);
            int rootIndexIn = map[preorder[rootIndexPre]];
            root.left = Construct(preorder, inorder, map, rootIndexPre + 1, left, rootIndexIn - 1);
            root.right = Construct(preorder, inorder, map, rootIndexPre + rootIndexIn - left + 1, rootIndexIn + 1, right);
            return root;
        }
    }
}