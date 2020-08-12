using System;
using System.Collections.Generic;

namespace P23
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            ListNode a = new ListNode(-8, new ListNode(-7, new ListNode(-7, new ListNode(-5, new ListNode(1, new ListNode(1, new ListNode(3, new ListNode(4))))))));
            ListNode b = new ListNode(-2);
            ListNode c = new ListNode(-10, new ListNode(-10, new ListNode(-7, new ListNode(0, new ListNode(1, new ListNode(3))))));
            ListNode d = new ListNode(2);
            ListNode[] lists = new ListNode[] { a, b, c, d };
            ListNode result = solution.MergeKLists(lists);
            while (result != null)
            {
                Console.Write(result.val + ", ");
                result = result.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }
            if (lists.Length == 1)
            {
                return lists[0];
            }
            MinHeap minHeap = new MinHeap();
            for (int i = 0; i < lists.Length; i++)
            {
                minHeap.Insert(lists[i]);
            }
            ListNode result = new ListNode();
            ListNode it = result;
            ListNode temp;
            while (!minHeap.IsEmpty)
            {
                temp = minHeap.Pop();
                it.next = new ListNode(temp.val);
                minHeap.Insert(temp.next);
                it = it.next;
            }
            return result.next;
        }
    }

    public class MinHeap
    {
        private List<ListNode> _list = new List<ListNode>();
        private ListNode _temp;

        public bool IsEmpty
        {
            get => _list.Count == 0;
        }

        public void Insert(ListNode node)
        {
            if (node == null)
            {
                return;
            }
            _list.Add(node);
            int current = _list.Count - 1;
            int futher = (current - 1) / 2;
            while (current != 0 && _list[current].val < _list[futher].val)
            {
                switchNodes(current, futher);
                current = futher;
                futher = (current - 1) / 2;
            }
        }

        public ListNode Pop()
        {
            ListNode result = _list[0];
            _list[0] = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            int current = 0;
            int l = 1;
            int r = 2;
            while (r < _list.Count)
            {
                int min = _list[l].val < _list[r].val ? l : r;
                if (_list[current].val > _list[min].val)
                {
                    switchNodes(current, min);
                    current = min;
                    l = min * 2 + 1;
                    r = l + 1;
                }
                else
                {
                    break;
                }
            }
            if (l < _list.Count && _list[current].val > _list[l].val)
            {
                switchNodes(current, l);
            }
            return result;
        }

        private void switchNodes(int a, int b)
        {
            _temp = _list[a];
            _list[a] = _list[b];
            _list[b] = _temp;
        }
    }
}