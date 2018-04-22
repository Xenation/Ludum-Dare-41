using UnityEngine;

namespace LD41 {
	public abstract class EnemyMover : MonoBehaviour {

		protected EnemyShip ship;
		protected ShootEmUpManager manager;
		protected ShipController playerShip;

		protected void Awake() {
			ship = GetComponent<EnemyShip>();
			manager = ShootEmUpManager.I;
			playerShip = manager.playerShip;
		}

	}
}
