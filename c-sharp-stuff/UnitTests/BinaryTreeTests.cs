using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void BinaryTreeRightSideView_ShouldReturn_ValueCollection()
        {
            var root = new BinaryTree.TreeNode(1, 
                new BinaryTree.TreeNode(2, null, 
                    new BinaryTree.TreeNode(5, null, null)), 
                new BinaryTree.TreeNode(3, null, 
                    new BinaryTree.TreeNode(4, null, null)));

            var rsv = new BinaryTree.RightSideView();

            var result = rsv.CalculateRightSideView(root);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 1, 3, 4}));
        }
    }
}
