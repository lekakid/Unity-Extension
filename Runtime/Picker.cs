using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LeKAKiD.Picker {
    public class Picker<T> {
        class Item {
            public T Value;
            public int Weight;

            public Item(T value, int weight) {
                Value = value;
                Weight = weight;
            }
        }

        List<Item> table = new List<Item>();

        public void Add(T value, int weight = 1) {
            table.Add(new Item(value, weight));
        }

        public T Pick() {
            if (!(table.Count > 0)) {
                throw new System.Exception("Empty List");
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

