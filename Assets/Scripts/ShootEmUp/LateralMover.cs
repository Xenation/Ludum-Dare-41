using UnityEngine;

namespace LD41.ShootEmUp {
	public class LateralMover : EnemyMover {

		public float maxX = 10f;
		public float minX = -10f;
		public bool passOnce = false;
		public float forwardMult = 0f;

		protected float side;

		protected void OnEnable() {
			side = (ship.transform.position.x > 0) ? -1f : 1f;
		}

		protected void FixedUpdate() {
			if (!passOnce) {
				if (ship.transform.position.x > maxX && side != -1f) {
					side = -1f;
				} else if (ship.transform.position.x < minX && side != 1f) {
					side = 1f;
				}
			}
			ship.velocity = new Vector2(side, -forwardMult).normalized * ship.speed;
		}

	}
}
