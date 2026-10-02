using System;
using System.Collections.Generic;

namespace MegaMulti.ListRandomnessExtensions
{
    public static class ListExtensions
    {
        private static readonly Random _random = new Random();

        // ============================================================
        // GetRandom
        // ============================================================

        /// <summary>
        /// Returns a random element from the list.
        /// Uses the shared random generator.
        /// </summary>
        public static T GetRandom<T>(this IList<T> list)
        {
            return list.GetRandom(_random);
        }

        /// <summary>
        /// Returns a random element from the list.
        /// Uses the provided random generator.
        /// </summary>
        public static T GetRandom<T>(this IList<T> list, Random random)
        {
            ValidateList(list);
            ValidateRandom(random);

            if (list.Count == 0)
                throw new InvalidOperationException("List is empty.");

            return list[random.Next(list.Count)];
        }


        // ============================================================
        // Shuffle
        // ============================================================

        /// <summary>
        /// Shuffles the list in place using the Fisher-Yates algorithm.
        /// Uses the shared random generator.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            list.Shuffle(_random);
        }

        /// <summary>
        /// Shuffles the list in place using the Fisher-Yates algorithm.
        /// Uses the provided random generator.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list, Random random)
        {
            ValidateList(list);
            ValidateRandom(random);

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }


        // ============================================================
        // PopLast
        // ============================================================

        /// <summary>
        /// Removes and returns the last element of the list.
        /// </summary>
        public static T PopLast<T>(this IList<T> list)
        {
            ValidateList(list);

            if (list.Count == 0)
                throw new InvalidOperationException("List is empty.");

            int lastIndex = list.Count - 1;
            T item = list[lastIndex];

            list.RemoveAt(lastIndex);

            return item;
        }


        // ============================================================
        // PopRandom
        // ============================================================

        /// <summary>
        /// Removes and returns a random element from the list.
        /// Uses the shared random generator.
        /// </summary>
        public static T PopRandom<T>(this IList<T> list)
        {
            return list.PopRandom(_random);
        }

        /// <summary>
        /// Removes and returns a random element from the list.
        /// Uses the provided random generator.
        /// </summary>
        public static T PopRandom<T>(this IList<T> list, Random random)
        {
            ValidateList(list);
            ValidateRandom(random);

            if (list.Count == 0)
                throw new InvalidOperationException("List is empty.");

            int index = random.Next(list.Count);
            T item = list[index];

            list.RemoveAt(index);

            return item;
        }


        // ============================================================
        // AddAtRandom
        // ============================================================

        /// <summary>
        /// Inserts an element at a random position in the list.
        /// Uses the shared random generator.
        /// </summary>
        public static void AddAtRandom<T>(this IList<T> list, T item)
        {
            list.AddAtRandom(item, _random);
        }

        /// <summary>
        /// Inserts an element at a random position in the list.
        /// Uses the provided random generator.
        /// </summary>
        public static void AddAtRandom<T>(
            this IList<T> list,
            T item,
            Random random)
        {
            ValidateList(list);
            ValidateRandom(random);

            int index = random.Next(list.Count + 1);

            list.Insert(index, item);
        }


        // ============================================================
        // Validation
        // ============================================================

        private static void ValidateList<T>(IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
        }

        private static void ValidateRandom(Random random)
        {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
        }
    }
}
