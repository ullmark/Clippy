using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clippy
{
    public static class LoopingExtensions
    {
        /// <summary>
        /// Runs the provided action for each of the items in the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            foreach (T item in collection)
                action(item);

            return collection;
        }

        /// <summary>
        /// Runs the provided action the value of amount times
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="action"></param>
        public static void Times(this int amount, Action<int> action)
        {
            for (var i = 0; i < amount; i++)
                action(i);
        }
    }
}
