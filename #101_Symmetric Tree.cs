using System;

namespace P101
{
    class Program
    {
        static void Main(string[] arags)
        {
            Solution solution = new Solution();
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(2);
            TreeNode node4 = new TreeNode(3);
            TreeNode node5 = new TreeNode(4);
            TreeNode node6 = new TreeNode(4);
            TreeNode node7 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;
            solution.IsSymmetric(node1);
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
        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root, root);
        }

        private bool IsMirror(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeA == null && nodeB == null)
            {
                return true;
            }
            if (nodeA == null || nodeB == null)
            {
                return false;
            }
            return nodeA.val == nodeB.val && IsMirror(nodeA.left, nodeB.right) && IsMirror(nodeA.right, nodeB.left);
        }
    }
}