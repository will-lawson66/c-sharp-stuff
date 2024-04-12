using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        [DataRow(4, 12, 0, 20, 4, null)]
        [DataRow(6, 4, 0, 100, 6, null)]
        public void FindInSortedArray_FindValidValue(int val, int length, int minValue, int maxValue, int? contains, int? notContains)
        {
            var testArray = CreateTestArray(length, minValue, maxValue, contains, notContains);
            Assert.IsTrue(BinarySearch.BinarySearch.FindInSortedArray(testArray, val));
        }

        public int[] CreateTestArray(int length, int minValue, int maxValue, int? contains = null, int? notContains = null)
        {
            var result = new int[length];
            
            Random randNum = new Random();

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = randNum.Next(minValue, maxValue);
            }

            var insert = randNum.Next(0, result.Length - 1);
            if (contains is not null)
            {
                result[insert] = (int)contains;
            }
            else if (notContains is not null) 
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == notContains) result[i] = (int)notContains + 1;
                }
            }
            Array.Sort(result);
            return result;
        }
    }
}
