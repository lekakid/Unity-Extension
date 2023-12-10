using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace LeKAKiD.List {
    public static class ListExtension {
        public static void Shuffle<T>(this IList<T> list) {
            Shuffle(list, (int)DateTime.Now.Ticks);
        }

        public static void Shuffle<T>(this IList<T> list, int seed) {
            Random.InitState(seed);

            int n = list.Count;
            while (n > 1) {
                n -= 1;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T Pop<T>(this IList<T> list, int index = -1) {
            if (index == -1) index = list.Count - 1;

            T result = list[index];
            list.RemoveAt(index);

            return result;
        }

        public static string Join<T>(this IList<T> list, string seperator = ", ") {
            return string.Join(seperator, list);
        }
    }
}
