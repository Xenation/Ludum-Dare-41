using UnityEngine;
using Xenon;

namespace LD41.ShootEmUp {
	public class ShootEmUpManager : Singleton<ShootEmUpManager> {

		public MapBounds mapBounds;
		public Camera cam;

		public TriggersManager triggersManager;
		public Transform mapTransform;
		public float mapSpeed = 10f;
		public Transform enemiesRoot;

		public ShipController playerShip;

		private void Awake() {
			if (cam != null) {
				cam.orthographicSize = (cam.pixelHeight / (float) cam.pixelWidth) * mapBounds.bounds.size.x / 2f;
				mapBounds.bounds.size = new Vector3(mapBounds.bounds.size.x, cam.orthographicSize * 2f, 0f);
			}
			triggersManager.Initialize(mapBounds.bounds);
			mapTransform.localScale = new Vector3(mapBounds.bounds.size.x, mapBounds.bounds.size.x);
		}

		private void FixedUpdate() {
			mapTransform.position += Vector3.down * mapSpeed * Time.fixedDeltaTime;
		}

	}
}
