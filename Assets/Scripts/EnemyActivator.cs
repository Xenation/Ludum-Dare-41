using UnityEngine;

namespace LD41 {
	[RequireComponent(typeof(EnemyShip))]
	public class EnemyActivator : MonoBehaviour {

		private EnemyShip ship;

		private void Awake() {
			ship = GetComponent<EnemyShip>();
		}

		private void FixedUpdate() {
			if (ship.spawnTrigger.OverlapPoint(transform.position)) {
				ship.Activate();
				enabled = false;
			}
		}

	}
}
