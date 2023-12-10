﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace LeKAKiD.List {
    public static class ListExtension {
        private static readonly Random rand = new Random();

        public static void Shuffle<T>(this IList<T> list) {
            int n = list.Count;
            while (n > 1) {
                n -= 1;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}