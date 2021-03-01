using Microsoft.VisualStudio.TestTools.UnitTesting;

using TelerikAcademy.Core;

namespace Core.Tests
{
    [TestClass]
    public class StringHelpersTests
    {
        [TestMethod]
        [DataRow("123456789", 3, "123...")]
        [DataRow("Telerik Academy Alpha .NET", 15, "Telerik Academy...")]
        [DataRow("Telerik Academy Alpha .NET", 30, "Telerik Academy Alpha .NET")]
        [DataRow("", 1, "")]
        public void Abbreviate_Should(string word, int wordMaxLength, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Abbreviate(word, wordMaxLength);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow("telerik", "Telerik")]
        [DataRow("Telerik", "Telerik")]
        public void Capitalize_Should(string word, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Capitalize(word);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("", "", "")]
        [DataRow("Telerik ", "Academy", "Telerik Academy")]
        public void Concat_Should(string word1, string word2, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Concat(word1, word2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("C#", '#', true)]
        [DataRow("C#", 'c', false)]
        public void Contains_Should(string word, char symbol, bool expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Contains(word, symbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("C#", 'C', true)]
        [DataRow("C#", 'c', false)]
        public void StartsWith_Should(string word, char symbol, bool expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.StartsWith(word, symbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("C#", '#', true)]
        [DataRow("C#", 'C', false)]
        public void EndsWith_Should(string word, char symbol, bool expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.EndsWith(word, symbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Telerik", 'e', 1)]
        [DataRow("Telerik", 'c', -1)]
        public void FirstIndexOf_Should(string word, char symbol, int expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.FirstIndexOf(word, symbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Telerik", 'e', 3)]
        [DataRow("Telerik", 'c', -1)]
        public void LastIndexOf_Should(string word, char symbol, int expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.LastIndexOf(word, symbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Telerik Academy", '-', 21, "---Telerik Academy---")]
        [DataRow("Telerik Academy", '-', 18, "-Telerik Academy-")]
        [DataRow("Telerik Academy", '-', 1, "Telerik Academy")]
        public void Pad_Should(string word, char paddingSymbol, int length, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Pad(word, length, paddingSymbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Telerik Academy", '-', 18, "Telerik Academy---")]
        public void PadEnd_Should(string word, char paddingSymbol, int length, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.PadEnd(word, length, paddingSymbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Telerik Academy", '-', 18, "---Telerik Academy")]
        public void PadStart_Should(string word, char paddingSymbol, int length, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.PadStart(word, length, paddingSymbol);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Alpha", 4, "AlphaAlphaAlphaAlpha")]
        [DataRow("Alpha", 0, "Alpha")]
        public void Repeat_Should(string word, int repeatTimes, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Repeat(word, repeatTimes);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Telerik Academy", "ymedacA kireleT")]
        public void Reverse_Should(string word, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Reverse(word);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("--Telerik Academy--", 2, 16, "Telerik Academy")]
        public void Section_Should(string word, int start, int end, string expected)
        {
            // The Arrange phase is performed by the DataRow attribute

            //Act
            var actual = StringHelpers.Section(word, start, end);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
