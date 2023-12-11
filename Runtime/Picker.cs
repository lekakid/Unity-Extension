using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace LeKAKiD.Picker {
    public class Picker<T> : IEnumerable<(T, int)> {
        private readonly List<(T Value, int Weight)> table = new List<(T Value, int Weight)>();

        public Picker() { }

        public Picker(IEnumerable<T> collection) {
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext()) {
                Add(enumerator.Current, 1);
            }
        }

        public IEnumerator<(T, int)> GetEnumerator() {
            return table.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public override string ToString() {
            return string.Join(", ", table);
        }

        public void Add(T value, int weight) {
            table.Add((value, weight));
        }

        public T Pick() {
            if (!(table.Count > 0)) {
                throw new Exception("Empty List");
            }

            int weightSum = table.Sum((item) => item.Weight);
            int weightAcc = 0;
            int randomValue = Random.Range(0, weightSum);

            for (int i = 0; i < table.Count; i += 1) {
                weightAcc += table[i].Weight;

                if (randomValue < weightAcc) {
                    return table[i].Value;
                }
            }

            return default;
        }
    }
}
