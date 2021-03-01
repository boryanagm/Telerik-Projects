using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LinearDataStructures
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        [DataRow(new int[0])]
        [DataRow(new[] { 0 })]
        [DataRow(new[] { 0, 1 })]
        [DataRow(new[] { 0, 1, 2 })]
        [DataRow(new[] { 0, 1, 2, 3 })]
        [DataRow(new[] { 0, 1, 2, 3, 4 })]
        public void Stack_Success_Cases(int[] testData)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(stack.Count, i, "The stack count is off");

                stack.Push(testData[i]);

                Assert.AreEqual(stack.Count, i + 1, "The stack count is off");

                Assert.AreEqual(testData[i], stack.Peek(), "The recently pushed value is not peeking");

                int counter = i;
                foreach (int value in stack)
                {
                    Assert.AreEqual(testData[counter], value, "The enumeration is not accurate");
                    counter--;
                }
            }

            Assert.AreEqual(testData.Length, stack.Count, "The end count was not as expected");

            for (int i = testData.Length - 1; i >= 0; i--)
            {
                int expected = testData[i];
                Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                Assert.AreEqual(i, stack.Count, "The popped value was not expected");
            }
        }

        [TestMethod]
        [DataRow(new int[0])]
        [DataRow(new[] { 0 })]
        [DataRow(new[] { 0, 1 })]
        [DataRow(new[] { 0, 1, 2 })]
        [DataRow(new[] { 0, 1, 2, 3 })]
        [DataRow(new[] { 0, 1, 2, 3, 4 })]
        public void Clear_Success_Cases(int[] testData)
        {
            Stack<int> s = new Stack<int>();

            foreach (int i in testData)
            {
                s.Push(i);
            }

            Assert.AreEqual(testData.Length, s.Count, "Count is not accurate");

            s.Clear();

            Assert.AreEqual(0, s.Count);

            foreach (int missing in s)
            {
                Assert.Fail("There should be nothing in the list");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Pop_From_Empty_Throws()
        {
            Stack<int> s = new Stack<int>();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Pop_From_Empty_Throws_After_Push()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Peek_From_Empty_Throws()
        {
            Stack<int> s = new Stack<int>();
            s.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Peek_From_Empty_Throws_After_Push()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Peek();
        }
    }
}