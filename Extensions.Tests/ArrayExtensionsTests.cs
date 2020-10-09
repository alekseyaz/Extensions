using NUnit.Framework;
using System.Linq;

namespace Zaac.Extensions.Tests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void ArrayFillTest()
        {
            var myArray = new int[12000];
            var filler = new int[] { 1, 2, 3, 4, 5 };

            myArray.Fill(filler);

            Assert.AreEqual(5, myArray.Last());
        }

        [Test]
        public void ArrayFillExactDoubleTest()
        {
            var myArray = new int[16384];

            myArray.Fill(7);

            Assert.AreEqual(7, myArray.Last());
        }

        [Test]
        public void ArrayFillTestUnevens()
        {
            for (var i = 0; i < 5; i++)
            {
                var myArray = new int[12001 + i];
                var filler = new int[] { 0, 1, 2, 3, 4, 5 };

                myArray.Fill(filler);

                Assert.AreEqual(i, myArray.Last());
            }
        }

        [Test]
        public void ArrayFillTestGiant()
        {
            for (var loopCount = 0; loopCount < 5; loopCount++)
            {
                var arrayLength = 200000000 - 4 + loopCount;
                var myArray = new byte[arrayLength];
                var filler = new byte[] { 0, 1, 2, 3, 4 };

                myArray.Fill(filler);

                var lastValue = myArray[arrayLength - 1];
                Assert.AreEqual(loopCount, lastValue);
            }
        }

        [Test]
        public void BubbleSortTest()
        {
            var actual = new int[] { 800, 11, 50, 771, 649, 770, 240, 9 };
            var expected = new int[] { 9, 11, 50, 240, 649, 770, 771, 800 };

            actual.BubbleSort();

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void QuickSortTest()
        {
            var actual = new int[] { 800, 11, 50, 771, 649, 770, 240, 9 };
            var expected = new int[] { 9, 11, 50, 240, 649, 770, 771, 800 };

            actual.QuickSort();

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void MergeSortTest()
        {
            var actual = new int[] { 800, 11, 50, 771, 649, 770, 240, 9 };
            var expected = new int[] { 9, 11, 50, 240, 649, 770, 771, 800 };

            actual.MergeSort();

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
