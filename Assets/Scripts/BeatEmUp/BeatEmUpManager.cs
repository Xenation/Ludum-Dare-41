using System.Collections.Generic;
using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	public class BeatEmUpManager : Singleton<BeatEmUpManager> {

		public MapBounds mapBounds;
		public Camera cam;

		public Transform enemiesRoot;

		public PlayerCharacter playerChar;

		public List<Terminal> terminals = new List<Terminal>();

		private void Awake() {
			if (cam != null) {
				cam.orthographicSize = (cam.pixelHeight / (float) cam.pixelWidth) * mapBounds.bounds.size.x / 2f;
				mapBounds.bounds.size = new Vector3(mapBounds.bounds.size.x, cam.orthographicSize * 2f, 0f);
			}
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

	}
}
