using LD41.ShootEmUp;

namespace LD41.Events {
	public class PlayerShipDamagedEvent : ShipEvent {

		public float damage;

		public PlayerShipDamagedEvent(Ship sh, float dmg) : base(sh) {
			damage = dmg;
		}
	}
}
