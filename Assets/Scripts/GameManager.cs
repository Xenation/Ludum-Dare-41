using LD41.Events;
using Xenon;

namespace LD41 {
	public class GameManager : Singleton<GameManager>, IEventListener, IEventSender {

		public int score = 0;

		private void Awake() {
			this.RegisterListener();
		}

		private void OnDestroy() {
			EventManager.I.UnregisterListener(this);
		}

		public void OnEnemyShipDeath(IEventSender sender, EnemyShipDeathEvent ev) {
			score += ev.ship.scoreGain;
			this.Send(new ScoreChangedEvent(score));
		}

	}
}
