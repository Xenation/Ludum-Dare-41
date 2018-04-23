using LD41.ShootEmUp;

namespace LD41.Events {
	public class EnemyShipDamagedEvent : ShipEvent {

		public float damage;

		public EnemyShipDamagedEvent(Ship sh, float dmg) : base(sh) {
			damage = dmg;
		}
	}
}
