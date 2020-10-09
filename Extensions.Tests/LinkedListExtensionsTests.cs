using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaac.Extensions.Tests
{
    [TestFixture]
    public class LinkedListExtensionsTests
    {

        [Test]
        public void ReversetTest()
        {
            var arrayint = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            LinkedList<int> actual = new LinkedList<int>(arrayint);
            LinkedList<int> expected = new LinkedList<int>(arrayint);

            actual.Reverse();
            Assert.AreNotEqual(actual, expected);
            actual.Reverse();
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetReverseTest()
        {
            var arrayint = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> actual = new LinkedList<int>(arrayint);
            LinkedList<int> expected = new LinkedList<int>();

            IEnumerator<int> it = actual.GetReverse().GetEnumerator();
            while (it.MoveNext())
            {
                expected.AddLast(it.Current);
            }

            Assert.AreNotEqual(actual, expected);

            LinkedList<int> expected2 = new LinkedList<int>();
            it = expected.GetReverse().GetEnumerator();
            while (it.MoveNext())
            {
                expected2.AddLast(it.Current);
            }

            Assert.AreEqual(actual, expected2);
        }

    }
}
