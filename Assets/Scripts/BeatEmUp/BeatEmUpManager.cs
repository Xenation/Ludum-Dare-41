using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	public class BeatEmUpManager : Singleton<BeatEmUpManager> {

		public MapBounds mapBounds;
		public Camera cam;

		public PlayerCharacter playerChar;

		private void Awake() {
			if (cam != null) {
				cam.orthographicSize = (cam.pixelHeight / (float) cam.pixelWidth) * mapBounds.bounds.size.x / 2f;
				mapBounds.bounds.size = new Vector3(mapBounds.bounds.size.x, cam.orthographicSize * 2f, 0f);
			}
		}

	}
}
