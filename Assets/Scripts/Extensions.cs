using UnityEngine;

namespace LD41 {
	public static class Extensions {

		public static float Remap(this float val, float from1, float to1, float from2, float to2) {
			return (val - from1) / (to1 - from1) * (to2 - from2) + from2;
		}

		public static Vector2 ClampMagnitude(this Vector2 vec, float minMag, float maxMag) {
			float mag = vec.magnitude;
			if (mag > maxMag) {
				return vec.normalized * maxMag;
			} else if (mag < minMag) {
				return vec.normalized * minMag;
			}
			return vec;
		}

		public static Vector2 RemapMagnitude(this Vector2 vec, float from1, float to1, float from2, float to2) {
			float mag = vec.magnitude.Remap(from1, to1, from2, to2);
			return vec.normalized * mag;
		}

	}
}
