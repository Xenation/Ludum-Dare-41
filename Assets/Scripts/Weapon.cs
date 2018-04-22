using System.Collections.Generic;
using UnityEngine;

namespace LD41 {
	public class Weapon : MonoBehaviour {

		protected List<ProjectileLauncher> launchers = new List<ProjectileLauncher>();

		protected float globalHeading = 0f;
		protected float relativeHeading = 0f; 

		protected void Awake() {
			GetComponentsInChildren(launchers);
			globalHeading = transform.rotation.eulerAngles.z;
		}

		public void SetRelativeHeading(float heading) {
			relativeHeading = heading;
			ResetHeading();
		}

		public void SetGlobalHeading(float heading) {
			globalHeading = heading;
			ResetHeading();
		}

		protected void ResetHeading() {
			transform.rotation = Quaternion.Euler(0, 0, globalHeading + relativeHeading);
		}

		public void Fire() {
			foreach (ProjectileLauncher launcher in launchers) {
				launcher.Launch();
			}
		}

	}
}
