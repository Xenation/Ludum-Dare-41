using Xenon;

namespace LD41.Processes {
	public abstract class EnemyShipProcess : Process {

		protected EnemyShip ship;

		public EnemyShipProcess(EnemyShip ship) {
			this.ship = ship;
		}

	}
}
