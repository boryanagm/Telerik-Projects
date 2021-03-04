using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructures
{
    [TestClass]
    public class Clear_Should
    {
        [TestMethod]
        public void Clear_Empty()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);

            list.Clear();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 0, 1 })]
        [DataRow(new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 0, 1, 2, 3 })]
        public void Clear_VariousItems(int[] testCase)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddLast(value);
            }

            Assert.IsNotNull(list.Head);
            Assert.IsNotNull(list.Tail);
            Assert.AreEqual(testCase.Length, list.Count);

            list.Clear();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }
    }
}
