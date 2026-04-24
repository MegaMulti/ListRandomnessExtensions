using System;
using System.Collections.Generic;

namespace MegaMulti.ListRandomnessExtensions
{
    public static class ListExtensions
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Returns a random element from the list.
        /// </summary>
        public static T GetRandom<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) throw new InvalidOperationException("List is empty.");

            return list[_random.Next(list.Count)];
        }

        /// <summary>
        /// Shuffles the list in place using the Fisher-Yates algorithm.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        /// <summary>
        /// Removes and returns the last element of the list.
        /// </summary>
        public static T PopLast<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) throw new InvalidOperationException("List is empty.");

            int lastIndex = list.Count - 1;
            T item = list[lastIndex];
            list.RemoveAt(lastIndex);
            return item;
        }

        /// <summary>
        /// Removes and returns a random element from the list.
        /// </summary>
        public static T PopRandom<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) throw new InvalidOperationException("List is empty.");

            int index = _random.Next(list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Inserts an element at a random position in the list.
        /// </summary>
        public static void AddAtRandom<T>(this IList<T> list, T item)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            int index = _random.Next(list.Count + 1);
            list.Insert(index, item);
        }
    }
}