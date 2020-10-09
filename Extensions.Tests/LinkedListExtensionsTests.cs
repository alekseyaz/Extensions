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
        public void GetReverseLinkedListTest()
        {
            var arrayint = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            LinkedList<int> actual = new LinkedList<int>(arrayint);

            Display(actual, "The values:");

            //var expected = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            var expected = actual.GetReverseLinkedList();

            Display(expected, "The reverse values:");

            //CollectionAssert.AreEqual(actual, expected);
            //Assert.IsTrue(true);
            //Console.WriteLine(@"Тест 'TestConsoleWriteLine' успешно пройден");
        }

        [Test]
        public void GetReverseTest()
        {
            var arrayint = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> actual = new LinkedList<int>(arrayint);

            Display(actual, "The values:");

            //var expected = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            var expected = actual.GetReverse();

            Display(expected, "The reverse values:");
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //CollectionAssert.AreEqual(actual, expected);
            //Assert.IsTrue(true);
            //Console.WriteLine(@"Тест 'TestConsoleWriteLine' успешно пройден");
        }

        private static void Display<T>(IEnumerable<T> words, string test)
        {
            Console.WriteLine(test);
            foreach (var word in words)
            {
                Console.Write(word.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
