using System;
using System.Collections.Generic;

namespace P94
{
    class Program
    {
        static void Main(string[] arags)
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
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }
            IList<int> result = new List<int>();
            Traverse(root, result);
            return result;
        }

        private void Traverse(TreeNode root, IList<int> result)
        {
            if (root.left != null)
            {
                Traverse(root.left, result);
            }
            result.Add(root.val);
            if (root.right != null)
            {
                Traverse(root.right, result);
            }
        }
    }
}