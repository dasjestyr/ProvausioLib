using System;
using System.Globalization;
using System.Linq;

namespace ProvausioLib.Portable.Extensions
{
    public static class StringEx
    {
        /// <summary>
        /// Tries to convert string to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">The target string</param>
        /// <param name="parsedValue">Output, if successful.</param>
        /// <returns>True/False indicating whether or not the parse was successful.</returns>
        public static bool TryConvert<T>(this string str, out T parsedValue)
        {
            try
            {
                parsedValue = (T) Convert.ChangeType(str, typeof (T), CultureInfo.InvariantCulture);
                return true;
            }

            catch { parsedValue = default(T); return false; }
        }

        public static T Cast<T>(this string str)
        {
            return (T) Convert.ChangeType(str, typeof (T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the string to snake_case
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string input)
        {
            return string.Concat(
                input.ToCharArray().Select(
                    (x, i) => i > 0 && char.IsUpper(x)
                        ? "_" + x.ToString()
                        : x.ToString()));
        }

        /// <summary>
        /// Converts the string to SCREAMING_SNAKE_CASE
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToScreamingSnakeCase(this string input)
        {
            var snakeCase = input.ToSnakeCase();
            return snakeCase.ToUpper();
        }
    }
}
