using System;

namespace Extensions
{
    public static class ArrayExtensions
    {
        // Inspired from several Stack Overflow discussions and an implementation by David Walker from http://coding.grax.com/2011/11/initialize-array-to-value-in-c-very.html
        public static void Fill<T>(this T[] destinationArray, params T[] value)
        {
            if (destinationArray == null)
            {
                throw new ArgumentNullException("destinationArray");
            }

            if (value.Length >= destinationArray.Length)
            {
                throw new ArgumentException("Length of value array must be less than length of destination");
            }

            // set the initial array value
            Array.Copy(value, destinationArray, value.Length);

            int arrayToFillHalfLength = destinationArray.Length / 2;
            int copyLength;

            for(copyLength = value.Length; copyLength < arrayToFillHalfLength; copyLength <<= 1)
            {
                Array.Copy(destinationArray, 0, destinationArray, copyLength, copyLength);
            }

            Array.Copy(destinationArray, 0, destinationArray, copyLength, destinationArray.Length - copyLength);
        }
    }
}
