using UnityEngine;

namespace LD41 {
	public class RotatingWeapon : Weapon {
		
		public AnimationCurve rotationCurve;

		private void Update() {
			SetRelativeHeading(360f * rotationCurve.Evaluate(Time.time % 1f));
		}

	}
}
