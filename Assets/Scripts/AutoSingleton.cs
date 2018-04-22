using UnityEngine;

namespace LD41 {
	public abstract class AutoSingleton<T> : MonoBehaviour where T : MonoBehaviour {

		protected static T instance;
		public static T I {
			get {
				if (instance == null) {
					instance = CreateInstance();
					if (instance == null) {
						Debug.LogWarning("Could not auto create singleton instance of " + typeof(T) + "! (make sure to redefine CreateInstance())");
					}
				}
				return instance;
			}
		}

		protected static T CreateInstance() {
			return null;
		}

	}
}
