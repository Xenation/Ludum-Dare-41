using LD41.ShootEmUp;
using Xenon.Processes;

namespace LD41.Processes {
	public abstract class TimedEnemyShipProcess : TimedProcess {

		protected EnemyShip ship;

		public TimedEnemyShipProcess(EnemyShip ship, float duration) : base(duration) {
			this.ship = ship;
		}

	}
}
