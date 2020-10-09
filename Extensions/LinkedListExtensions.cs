using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaac.Extensions
{
    public static class LinkedListExtensions
    {

        public static IEnumerable<T> GetReverse<T>(this LinkedList<T> list)
        {
            var el = list.Last;
            while (el != null)
            {
                yield return el.Value;
                el = el.Previous;
            }
        }
        public static void Reverse<T>(this LinkedList<T> list)
        {
            var head = list.First;
            while (head.Next != null)
            {
                var next = head.Next;
                list.Remove(next);
                list.AddFirst(next.Value);
            }
        }

    }
}
