using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    public class RightSideView
    {
        public IList<int> CalculateRightSideView(TreeNode root)
        {
            if (root == null) return new List<int>();

            List<int> result = new List<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                int thisLevelResult = 0;
                Queue<TreeNode> nextLevelQueue = new Queue<TreeNode>();

                while (queue.Any())
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) nextLevelQueue.Enqueue(node.left);
                    if (node.right != null) nextLevelQueue.Enqueue(node.right);
                    thisLevelResult = node.val;
                }

                result.Add(thisLevelResult);
                queue = nextLevelQueue;
            }

            return result;
        }

    }

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

