using LD41.ShootEmUp;
using Xenon;

namespace LD41.Events {
	public class ShipEvent : XEvent {

		public Ship ship;

		public ShipEvent(Ship sh) {
			ship = sh;
		}

	}
}
