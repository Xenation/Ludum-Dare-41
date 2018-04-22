using UnityEngine;

namespace LD41.ShootEmUp {
	public class FollowMover : StayingMover {

		public float minDistance = 3f;
		public float slowDistance = 4f;

		private void FixedUpdate() {
			if (!isLeaving) {
				Vector2 toPlayer = playerShip.transform.position - transform.position;
				ship.velocity = toPlayer.RemapMagnitude(minDistance, slowDistance, 0f, ship.speed).ClampMagnitude(0, ship.speed);
			} else {
				ship.velocity = Vector2.down * ship.speed;
			}
		}
	}
}
