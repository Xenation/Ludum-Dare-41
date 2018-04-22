using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41 {
	public class GameManager : Singleton<GameManager>, IEventListener {

		public int score = 0;

		private void Awake() {
			this.RegisterListener();
		}

		private void OnDestroy() {
			EventManager.I.UnregisterListener(this);
		}

		public void OnShipKilled(IEventSender sender, ShipKilledEvent ev) {
			score += ev.ship.scoreGain;
		}

	}
}
