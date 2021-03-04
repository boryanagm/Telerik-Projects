using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructures
{
    [TestClass]
    public class Add_Should
    {
        [TestMethod]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 0, 1 })]
        [DataRow(new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 0, 1, 2, 3 })]
        public void Add_Raw_Value_Success_Cases(int[] testCase)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddFirst(value);
            }

            Assert.AreEqual(testCase.Length, list.Count, "There was an unexpected number of list items");

            Assert.AreEqual(testCase.Last(), list.Head.Value, "The first item value was incorrect");

            Assert.AreEqual(testCase.First(), list.Tail.Value, "The last item value was incorrect");

            int[] reversed = testCase.Reverse().ToArray();
            int current = 0;

            foreach (int value in list)
            {
                Assert.AreEqual(reversed[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [TestMethod]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 0, 1 })]
        [DataRow(new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 0, 1, 2, 3 })]
        public void AddFirst_Node_Value_Success_Cases(int[] testCase)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddFirst(value);
            }

            Assert.AreEqual(testCase.Length, list.Count, "There was an unexpected number of list items");

            Assert.AreEqual(testCase.Last(), list.Head.Value, "The first item value was incorrect");

            Assert.AreEqual(testCase.First(), list.Tail.Value, "The last item value was incorrect");

            int[] reversed = testCase.Reverse().ToArray();

            int current = 0;

            foreach (int value in list)
            {
                Assert.AreEqual(reversed[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [TestMethod]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 0, 1 })]
        [DataRow(new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 0, 1, 2, 3 })]
        public void AddLast_Raw_Value_Success_Cases(int[] testCase)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddLast(value);
            }

            Assert.AreEqual(testCase.Length, list.Count, "There was an unexpected number of list items");

            Assert.AreEqual(testCase.First(), list.Head.Value, "The first item value was incorrect");

            Assert.AreEqual(testCase.Last(), list.Tail.Value, "The last item value was incorrect");

            int current = 0;
            foreach (int value in list)
            {
                Assert.AreEqual(testCase[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [TestMethod]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 0, 1 })]
        [DataRow(new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 0, 1, 2, 3 })]
        public void AddLast_Node_Value_Success_Cases(int[] testCase)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddLast(value);
            }

            Assert.AreEqual(testCase.Length, list.Count, "There was an unexpected number of list items");

            Assert.AreEqual(testCase.First(), list.Head.Value, "The first item value was incorrect");

            Assert.AreEqual(testCase.Last(), list.Tail.Value, "The last item value was incorrect");

            int current = 0;
            foreach (int value in list)
            {
                Assert.AreEqual(testCase[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }
    }
}
