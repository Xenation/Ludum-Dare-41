using Xenon;

namespace LD41.Events {
	public class ScoreChangedEvent : XEvent {

		public int score;

		public ScoreChangedEvent(int score) {
			this.score = score;
		}
	}
}
