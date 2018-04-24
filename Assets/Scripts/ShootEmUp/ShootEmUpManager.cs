using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.ShootEmUp {
	public class ShootEmUpManager : Singleton<ShootEmUpManager>, IEventListener, IEventSender {

		public MapBounds mapBounds;
		public Camera cam;

		public TriggersManager triggersManager;
		public Transform mapTransform;
		public float mapSpeed = 10f;
		public Transform enemiesRoot;

		public ShipController playerShip;
		public EnemyShip finalShip;

		protected float totalDistance;
		[System.NonSerialized]
		public float portionReached;

		private void Awake() {
			if (cam != null) {
				cam.orthographicSize = (cam.pixelHeight / (float) cam.pixelWidth) * mapBounds.bounds.size.x / 2f;
				mapBounds.bounds.size = new Vector3(mapBounds.bounds.size.x, cam.orthographicSize * 2f, 0f);
			}
			triggersManager.Initialize(mapBounds.bounds);
			mapTransform.localScale = new Vector3(mapBounds.bounds.size.x, mapBounds.bounds.size.x);
			this.RegisterListener();
			totalDistance = finalShip.transform.position.y;
		}

		private void OnDestroy() {
			this.UnregisterListener();
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Keypad0)) {
				mapSpeed = 0f;
			}
			if (Input.GetKeyDown(KeyCode.Keypad1)) {
				mapSpeed = 5f;
			}
			if (Input.GetKeyDown(KeyCode.Keypad2)) {
				mapSpeed = 10f;
			}
			if (Input.GetKeyDown(KeyCode.Keypad3)) {
				mapSpeed = 15f;
			}
			if (Input.GetKeyDown(KeyCode.Keypad8)) {
				mapSpeed = 40f;
			}
		}

		private void FixedUpdate() {
			mapTransform.position += Vector3.down * mapSpeed * Time.fixedDeltaTime;
			portionReached = 1f - (finalShip.transform.position.y) / totalDistance;
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

		private void OnPlayerDeath(Ship player) {

		}

		public void OnEnemyShipDeath(IEventSender sender, EnemyShipDeathEvent ev) {
			if (ev.ship == finalShip) {
				this.Send(new GameWonEvent());
			}
		}

	}
}
