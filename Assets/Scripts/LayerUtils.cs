using UnityEngine;

namespace LD41 {
	public static class LayerUtils {

		private static int playerLayer;
		public static int Player {
			get {
				if (playerLayer == 0) {
					playerLayer = LayerMask.NameToLayer("Player");
				}
				return playerLayer;
			}
		}

		private static int playerProjectileLayer;
		public static int PlayerProjectile {
			get {
				if (playerProjectileLayer == 0) {
					playerProjectileLayer = LayerMask.NameToLayer("PlayerProjectile");
				}
				return playerProjectileLayer;
			}
		}

		private static int enemyLayer;
		public static int Enemy {
			get {
				if (enemyLayer == 0) {
					enemyLayer = LayerMask.NameToLayer("Enemy");
				}
				return enemyLayer;
			}
		}

		private static int enemyProjectileLayer;
		public static int EnemyProjectile {
			get {
				if (enemyProjectileLayer == 0) {
					enemyProjectileLayer = LayerMask.NameToLayer("EnemyProjectile");
				}
				return enemyProjectileLayer;
			}
		}

		private static int enemyTriggerLayer;
		public static int EnemyTrigger {
			get {
				if (enemyTriggerLayer == 0) {
					enemyTriggerLayer = LayerMask.NameToLayer("EnemyTrigger");
				}
				return enemyTriggerLayer;
			}
		}

	}
}
