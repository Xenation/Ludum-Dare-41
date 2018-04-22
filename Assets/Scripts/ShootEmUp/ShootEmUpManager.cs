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

		private void OnDrawGizmos() {
			float farLeft = -mapBounds.bounds.extents.x - mapBounds.bounds.size.x;
			float left = -mapBounds.bounds.extents.x;
			float right = -left;
			float farRight = -farLeft;
			Color prevColor = Gizmos.color;
			Gizmos.color = Color.blue; // Lanes
			Gizmos.DrawLine(new Vector3(farLeft, -100f), new Vector3(farLeft, 1000f));
			Gizmos.DrawLine(new Vector3(left, -100f), new Vector3(left, 1000f));
			Gizmos.DrawLine(new Vector3(right, -100f), new Vector3(right, 1000f));
			Gizmos.DrawLine(new Vector3(farRight, -100f), new Vector3(farRight, 1000f));

			Gizmos.color = Color.red; // Screen top/bottom
			float top = mapBounds.bounds.extents.y;
			float bottom = -top;
			Gizmos.DrawLine(new Vector3(left, top), new Vector3(right, top));
			Gizmos.DrawLine(new Vector3(left, bottom), new Vector3(right, bottom));

			Gizmos.color = Color.green; // Triggers
			float triggTop = mapBounds.bounds.extents.y + 1f;
			float triggHigh = -mapBounds.bounds.extents.y + mapBounds.bounds.size.y * triggersManager.highRatio;
			float triggMid = -mapBounds.bounds.extents.y + mapBounds.bounds.size.y * triggersManager.middleRatio;
			float triggLow = -mapBounds.bounds.extents.y + mapBounds.bounds.size.y * triggersManager.lowRatio;
			Gizmos.DrawLine(new Vector3(left, triggTop), new Vector3(right, triggTop));
			Gizmos.DrawLine(new Vector3(farLeft, triggHigh), new Vector3(left, triggHigh));
			Gizmos.DrawLine(new Vector3(farLeft, triggMid), new Vector3(left, triggMid));
			Gizmos.DrawLine(new Vector3(farLeft, triggLow), new Vector3(left, triggLow));
			Gizmos.DrawLine(new Vector3(farRight, triggHigh), new Vector3(right, triggHigh));
			Gizmos.DrawLine(new Vector3(farRight, triggMid), new Vector3(right, triggMid));
			Gizmos.DrawLine(new Vector3(farRight, triggLow), new Vector3(right, triggLow));

			Gizmos.color = prevColor;
		}

	}
}
