using UnityEngine;

namespace LD41.Processes {
	public class EnemyEnterTranslationProcess : EnemyShipProcess {

		protected float side;
		protected float distance;

		private float startX;

		public EnemyEnterTranslationProcess(EnemyShip ship, float side, float distance) : base(ship) {
			this.side = side;
			this.distance = distance;
		}

		public override void OnBegin() {
			startX = ship.transform.position.x;
			ship.velocity = new Vector2(-side * ship.speed, 0);
		}

		public override void OnTerminate() {
			ship.velocity = Vector2.zero;
			ship.SwitchState(EnemyShip.State.Active);
		}

		public override void Update(float dt) {
			if (Mathf.Abs(ship.transform.position.x - startX) > distance) {
				Terminate();
			}
		}

	}
}
