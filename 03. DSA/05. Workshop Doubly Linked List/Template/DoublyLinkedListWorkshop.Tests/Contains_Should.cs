using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructures
{
    [TestClass]
    public class Contains_Should
    {
        [TestMethod]
        public void Find_Empty()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.IsFalse(list.Contains(10), "Nothing should have been found.");
        }

        [TestMethod]
        [DataRow(new int[] { 0 }, 10)]
        [DataRow(new int[] { 0, 1 }, 10)]
        [DataRow(new int[] { 0, 1, 2 }, 10)]
        [DataRow(new int[] { 0, 1, 2, 3 }, 10)]
        public void Find_Missing(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(data);
            }

            Assert.IsFalse(list.Contains(value), "Nothing should have been found.");
        }

        [TestMethod]
        [DataRow(new int[] { 10 }, 10)]
        [DataRow(new int[] { 10, 0 }, 10)]
        [DataRow(new int[] { 0, 10 }, 10)]
        [DataRow(new int[] { 0, 1, 10 }, 10)]
        [DataRow(new int[] { 0, 10, 0 }, 10)]
        public void Find_Found(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(data);
            }

            Assert.IsTrue(list.Contains(value), "There should have been a node found");
        }
    }
}
