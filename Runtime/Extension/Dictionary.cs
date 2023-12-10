using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeKAKiD.Dictionary {
    public static class DictionaryExtension {
        public static string GetEntriesString<K, V>(this IDictionary<K, V> dictionary) {
            List<string> entryStringList = new List<string>();

            var enumerator = dictionary.GetEnumerator();
            while (enumerator.MoveNext()) {
                entryStringList.Add(enumerator.Current.ToString());
            }

            return string.Join(", ", entryStringList);
        }
    }
}