using LD41.BeatEmUp;

namespace LD41.Events {
	public class PlayerCharacterDamagedEvent : CharacterEvent {

		public float damage;

		public PlayerCharacterDamagedEvent(Character ch, float dmg) : base(ch) {
			damage = dmg;
		}
	}
}
