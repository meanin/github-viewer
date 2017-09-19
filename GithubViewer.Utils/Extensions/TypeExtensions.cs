using System;
using System.Collections.Generic;

namespace GithubViewer.Utils.Extensions
{
    /// <summary>
    /// Extensions for type
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Check if given type is type of T
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="type">Type object</param>
        /// <returns>true if requirements are fullfilled, false otherwise</returns>
        public static bool IsTypeofOrIEnumerableOf<T>(this Type type)
        {
            return type == typeof(T) || typeof(IEnumerable<T>).IsAssignableFrom(type);
        }
    }
}
