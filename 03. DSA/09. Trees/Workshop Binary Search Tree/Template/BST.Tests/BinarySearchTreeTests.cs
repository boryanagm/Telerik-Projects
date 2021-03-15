using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace BST.Tests
{
	[TestClass]
	public class BinarySearchTreeTests
	{
		private BinarySearchTree<int> testTree;

		private void PrepareTestTree()
		{
			this.testTree = new BinarySearchTree<int>(50);
			this.testTree.Insert(30);
			this.testTree.Insert(20);
			this.testTree.Insert(40);
			this.testTree.Insert(70);
			this.testTree.Insert(60);
			this.testTree.Insert(80);
			this.testTree.Insert(72);
			this.testTree.Insert(71);
		}

		[TestMethod]
		public void Constructor_Should_CreateTreeWithSingleNode()
		{
			// Arrange, Act
			testTree = new BinarySearchTree<int>(5);

			// Assert
			Assert.AreEqual(5, testTree.GetRootValue());
			Assert.IsNull(testTree.GetLeftTree());
			Assert.IsNull(testTree.GetRightTree());
		}

		public void Insert_Should_AddLeftNodeCorrectly_When_TreeHasRootOnly()
		{
			// Arrange
			testTree = new BinarySearchTree<int>(5);

			// Act
			testTree.Insert(4);

			// Assert
			Assert.AreEqual(4, testTree.GetLeftTree().GetRootValue());
		}

		public void Insert_Should_AddRightNodeCorrectly_When_TreeHasRootOnly()
		{
			//Arrange
			testTree = new BinarySearchTree<int>(5);

			// Act
			testTree.Insert(7);

			// Assert
			Assert.AreEqual(7, testTree.GetRightTree().GetRootValue());
		}

		public void Insert_Should_AddLeftNodeCorrectly_When_TreeHasMultipleNodes()
		{
			// Arrange
			PrepareTestTree();

			// Act
			testTree.Insert(25);

			// Assert
			Assert.AreEqual(25, testTree.GetLeftTree().GetLeftTree().GetRightTree().GetRootValue());
		}

		public void Insert_Should_AddRightNodeCorrectly_When_TreeHasMultipleNodes()
		{
			// Arrange
			PrepareTestTree();

			// Act
			testTree.Insert(65);

			// Assert
			Assert.AreEqual(65, testTree.GetRightTree().GetLeftTree().GetRightTree().GetRootValue());
		}

		[TestMethod]
		public void Search_Should_ReturnFalse_When_SingleNotMatchingNode()
		{
			// Act
			testTree = new BinarySearchTree<int>(5);

			// Act, Assert
			Assert.IsFalse(testTree.Search(50));
		}

		[TestMethod]
		public void Search_Should_ReturnFalse_When_NodeDoesNotExist()
		{
			// Arrange
			PrepareTestTree();

			// Act, Assert
			Assert.IsFalse(testTree.Search(5));
		}

		[TestMethod]
		public void Search_Should_ReturnTrue_When_SingleMatchingNode()
		{
			// Arrange
			testTree = new BinarySearchTree<int>(5);

			// Act, Assert
			Assert.IsTrue(testTree.Search(5));
		}

		[TestMethod]
		public void Search_Should_ReturnTrue_When_TreeHasMultipleNodes()
		{
			PrepareTestTree();

			// Act, Assert
			Assert.IsTrue(testTree.Search(60));
		}


		[TestMethod]
		public void GetPreOrder_Should_ReturnElementsInRightSequence()
		{
			// Arrange
			PrepareTestTree();
			int[] expected = { 50, 30, 20, 40, 70, 60, 80, 72, 71 };

			// Act
			IList<int> result = testTree.GetPreOrder();

			// Assert
			CollectionAssert.AreEqual(expected, result.ToArray());
		}

		[TestMethod]
		public void GetInOrder_Should_ReturnElementsInRightSequence()
		{
			// Arrange
			PrepareTestTree();
			int[] expected = { 20, 30, 40, 50, 60, 70, 71, 72, 80 };

			// Act
			IList<int> result = testTree.GetInOrder();

			// Assert
			CollectionAssert.AreEqual(expected, result.ToArray());
		}

		[TestMethod]
		public void GetPostOrder_Should_ReturnElementsInRightSequence()
		{
			// Arrange
			PrepareTestTree();
			int[] expected = { 20, 40, 30, 60, 71, 72, 80, 70, 50 };

			// Act
			IList<int> result = testTree.GetPostOrder();

			// Assert
			CollectionAssert.AreEqual(expected, result.ToArray());
		}

		[TestMethod]
		public void GetBFS_Should_ReturnElementsInRightSequence()
		{
			// Arrange
			PrepareTestTree();
			int[] expected = { 50, 30, 70, 20, 40, 60, 80, 72, 71 };

			// Act
			IList<int> result = testTree.GetBFS();

			// Assert
			CollectionAssert.AreEqual(expected, result.ToArray());
		}

		[TestMethod]
		public void Height_Should_ReturnZero_When_TreeHasRootOnly()
		{
			// Arrange
			testTree = new BinarySearchTree<int>(5);

			// Act & Assert
			Assert.AreEqual(0, testTree.Height);
		}

		[TestMethod]
		public void Height_Should_ReturnCorrectHeight_When_TreeHasMultipleNodes()
		{
			// Arrange
			PrepareTestTree();

			// Act & Assert
			Assert.AreEqual(4, testTree.Height);
		}

		// Uncomment when implementing remove method
		///*
			[TestMethod]
			public void Remove_Should_ReturnFalse_When_SingleNotMatchingItem()
			{
				// Arrange
				testTree = new BinarySearchTree<int>(5);

				// act, Assert
				Assert.IsFalse(testTree.Remove(6));
			}

			[TestMethod]
			public void Remove_Should_ReplaceRoot_When_ValueToBeRemovedIsInRoot()
			{
				// Arrange
				PrepareTestTree();

				// Act, Assert
				Assert.IsTrue(testTree.Remove(50));
				Assert.AreEqual(40, testTree.GetRootValue());
			}

			[TestMethod]
			public void Remove_Should_MaintainCorrectOrdering_When_ValuePresentAndHasRightChildOnly()
			{
				// Arrange
				PrepareTestTree();
				testTree.Insert(42);

				// Act
				testTree.Remove(40);

				// Assert
				Assert.AreEqual(42, testTree.GetLeftTree().GetRightTree().GetRootValue());
			}

			[TestMethod]
			public void Remove_Should_MaintainCorrectOrdering_When_ValuePresentAndHasLeftChildOnly()
			{
				// Arrange
				PrepareTestTree();
				testTree.Insert(39);

				// Act
				testTree.Remove(40);

				// Assert
				Assert.AreEqual(39, testTree.GetLeftTree().GetRightTree().GetRootValue());
			}

			[TestMethod]
			public void Remove_Should_MaintainCorrectOrdering_WhenValuePresentAndHasBothChildren()
			{
				// Arrange
				PrepareTestTree();
				// Act
				testTree.Remove(70);
				// Assert
				Assert.AreEqual(60, testTree.GetRightTree().GetRootValue());
				Assert.IsNull(testTree.GetRightTree().GetLeftTree());
			}
		//*/
	}
}
