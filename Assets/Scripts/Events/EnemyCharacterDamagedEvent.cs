using LD41.BeatEmUp;

namespace LD41.Events {
	public class EnemyCharacterDamagedEvent : CharacterEvent {

		public Character inflicter;
		public float damage;

		public EnemyCharacterDamagedEvent(Character ch, Character inflicter, float dmg) : base(ch) {
			this.inflicter = inflicter;
			damage = dmg;
		}
	}
}
