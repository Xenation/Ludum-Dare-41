using System.Collections.Generic;
using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	public class BeatEmUpManager : Singleton<BeatEmUpManager>, IEventListener {

		public MapBounds mapBounds;
		public Camera cam;

		public Transform enemiesRoot;

		public PlayerCharacter playerChar;
		public Transform playerSpawn;

		public List<Terminal> terminals = new List<Terminal>();

		private void Awake() {
			if (cam != null) {
				cam.orthographicSize = (cam.pixelHeight / (float) cam.pixelWidth) * mapBounds.bounds.size.x / 2f;
				mapBounds.bounds.size = new Vector3(mapBounds.bounds.size.x, cam.orthographicSize * 2f, 0f);
			}
			this.RegisterListener();
		}

		private void OnDestroy() {
			this.UnregisterListener();
		}

		public Terminal GetClosestEnabledTerminal(Vector3 pos) {
			Terminal closestTerminal = null;
			float shortestDistance = 1000000f;
			foreach (Terminal terminal in terminals) {
				if (!terminal.isEnabled) continue;
				float distance = (pos - terminal.transform.position).sqrMagnitude;
				if (distance < shortestDistance) {
					closestTerminal = terminal;
					shortestDistance = distance;
				}
			}
			return closestTerminal;
		}

		public void OnPlayerCharacterDeath(IEventSender sender, PlayerCharacterDeathEvent ev) {
			playerChar.transform.position = playerSpawn.position;
			playerChar.health = 10f;
		}

	}
}
