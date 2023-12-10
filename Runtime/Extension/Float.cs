using UnityEngine;

namespace LeKAKiD.Float {
    public static class FloatExtension {
        public static float Remap(this float value, float prevA, float prevB, float nextA = 0, float nextB = 1) {
            float normalizedValue = Mathf.InverseLerp(prevA, prevB, value);
            return Mathf.Lerp(nextA, nextB, normalizedValue);
        }
    }
}