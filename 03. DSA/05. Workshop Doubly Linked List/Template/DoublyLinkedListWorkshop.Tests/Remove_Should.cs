using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructures
{
    [TestClass]
    public class Remove_Should
    {
        [TestMethod]
        public void RemoveFirstLast_Empty_Lists()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void RemoveFirstLast_One_Node()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(10);
            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.AddFirst(10);
            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void RemoveFirstLast_Two_Node()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(10);
            list.AddFirst(20);

            list.RemoveFirst();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);

            list.AddFirst(10);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);
        }


        [TestMethod]
        public void RemoveFirst_Ten_Nodes()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, list.Count, "Unexpected list count");
                list.RemoveFirst();
            }

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void RemoveLast_Ten_Nodes()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, list.Count, "Unexpected list count");
                list.RemoveLast();
            }

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        [DataRow(new int[] { 0 }, 10)]
        [DataRow(new int[] { 0, 1 }, 10)]
        [DataRow(new int[] { 0, 1, 2 }, 10)]
        [DataRow(new int[] { 0, 1, 2, 3 }, 10)]
        public void Remove_Missing(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(data);
            }

            Assert.IsFalse(list.Remove(value), "Nothing should have been removed");
            Assert.AreEqual(testData.Length, list.Count, "The expected list count was incorrect");
        }

        [TestMethod]
        [DataRow(new int[] { 10 }, 10)]
        [DataRow(new int[] { 10, 0 }, 10)]
        [DataRow(new int[] { 0, 10 }, 10)]
        [DataRow(new int[] { 0, 0, 10 }, 10)]
        [DataRow(new int[] { 0, 10, 0 }, 10)]
        [DataRow(new int[] { 10, 0, 0 }, 10)]
        public void Remove_Found(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.AddLast(data);
            }

            Assert.IsTrue(list.Remove(value), "A node should have been removed");
            Assert.AreEqual(testData.Length - 1, list.Count, "The expected list count was incorrect");
        }
    }
}
