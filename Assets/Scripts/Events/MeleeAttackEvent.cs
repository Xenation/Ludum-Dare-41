using LD41.BeatEmUp;
using Xenon;

namespace LD41.Events {
	public class MeleeAttackEvent : XEvent {

		public MeleeController melee;

		public MeleeAttackEvent(MeleeController melee) {
			this.melee = melee;
		}

	}
}
