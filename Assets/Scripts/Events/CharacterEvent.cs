using LD41.BeatEmUp;
using Xenon;

namespace LD41.Events {
	public class CharacterEvent : XEvent {

		public Character character;

		public CharacterEvent(Character ch) {
			character = ch;
		}
	}
}
