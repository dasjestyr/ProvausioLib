using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProvausioLib.Portable.Extensions
{
    public static class EnumerationEx
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection != null)
                return !collection.Any();

            return true;
        }

        /// <summary>
        /// Counts the specified non-generic enumerable source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static int Count(this IEnumerable source)
        {
            return source
                .Cast<object>()
                .Count<object>();
        }

        /// <summary>
        /// Separates all known values from a masked enum (Flags)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mask">The mask.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Argument must be an enumeration</exception>
        public static IEnumerable<T> UnMaskFlags<T>(this Enum mask)
            where T : struct
        {
            if (!typeof(T).IsSubclassOf(typeof(Enum)))
                throw new ArgumentException("Argument must be an enumeration", nameof(mask));

            return Enum.GetValues(typeof(T)).Cast<Enum>().Where(mask.HasFlag).Cast<T>();
        }
    }
}
