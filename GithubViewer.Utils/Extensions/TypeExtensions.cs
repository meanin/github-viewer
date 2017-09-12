using System;
using System.Collections.Generic;

namespace GithubViewer.Utils.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsTypeofOrIEnumerableOf<T>(this Type type)
        {
            return type == typeof(T) || typeof(IEnumerable<T>).IsAssignableFrom(type);
        }
    }
}
