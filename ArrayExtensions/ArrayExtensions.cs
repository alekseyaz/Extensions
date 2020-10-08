using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaac.Extensions
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] destinationArray, params T[] value)
        {
            if (destinationArray == null)
            {
                throw new ArgumentNullException(nameof(destinationArray));
            }

            if (value.Length > destinationArray.Length)
            {
                throw new ArgumentException("Длина массива значений не должна быть больше длины массива назначения");
            }

            Array.Copy(value, destinationArray, value.Length);

            var copyLength = value.Length;
            var destinationArrayHalfLength = destinationArray.Length / 2;

            for (; copyLength < destinationArrayHalfLength; copyLength *= 2)
            {
                Array.Copy(destinationArray, 0, destinationArray, copyLength, copyLength);
            }

            Array.Copy(destinationArray, 0, destinationArray, copyLength, destinationArray.Length - copyLength);
        }

    }
}
