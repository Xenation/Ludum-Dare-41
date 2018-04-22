using UnityEngine;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class EnemyCharacter : Character {

		public float minDistance = .7f;
		public float slowDistance = 2f;
		public float hitRange = 1f;

		protected PlayerCharacter playerChar;

		protected new void Awake() {
			base.Awake();
			playerChar = manager.playerChar;
		}

		protected new void FixedUpdate() {
			if (!isStunned) {
				Vector2 toPlayer = playerChar.transform.position - transform.position;
				velocity = toPlayer.RemapMagnitude(minDistance, slowDistance, 0f, speed).ClampMagnitude(0, speed);

				if (toPlayer.magnitude < hitRange) {
					melee.Hit();
				}
			}
			base.FixedUpdate();
		}

	}
}
