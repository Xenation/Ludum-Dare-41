using UnityEngine;

namespace LD41 {
	[System.Serializable]
	public class MapBounds {

		public Bounds bounds;
		public float killYMargin = 4f;

		public MapBounds(Bounds bounds) {
			this.bounds = bounds;
		}

		public void KeepVelocityInBounds(Vector2 pos, ref Vector2 velocity, float dt) {
			KeepVelocityInSideBounds(pos, ref velocity, dt);
			if (velocity.y > 0) {
				velocity.y = Mathf.Clamp(velocity.y * dt, 0f, bounds.max.y - pos.y) / dt;
			} else if (velocity.y < 0) {
				velocity.y = Mathf.Clamp(velocity.y * dt, bounds.min.y - pos.y, 0f) / dt;
			}
		}

		public void KeepVelocityInSideBounds(Vector2 pos, ref Vector2 velocity, float dt) {
			if (velocity.x > 0) {
				velocity.x = Mathf.Clamp(velocity.x * dt, 0f, bounds.max.x - pos.x) / dt;
			} else if (velocity.x < 0) {
				velocity.x = Mathf.Clamp(velocity.x * dt, bounds.min.x - pos.x, 0f) / dt;
			}
		}

		public bool IsInBounds(Vector2 pos, float margin = 0f) {
			Bounds marginBounds = new Bounds(bounds.center, bounds.size);
			marginBounds.Expand(margin);
			return marginBounds.Contains(pos);
		}

		public bool WillBeInBounds(Vector2 pos, Vector2 vel, float dt, float margin = 0f) {
			Bounds marginBounds = new Bounds(bounds.center, bounds.size);
			marginBounds.Expand(margin);
			return marginBounds.Contains(pos + vel * dt);
		}

		public bool BellowKillY(Vector2 pos) {
			return pos.y < bounds.center.y - bounds.extents.y - killYMargin;
		}

		public void DebugDraw() {
			Debug.DrawLine(bounds.min, bounds.min + Vector3.up * bounds.extents.y * 2, Color.red);
			Debug.DrawLine(bounds.min + Vector3.right * bounds.extents.x * 2, bounds.max, Color.red);
			Debug.DrawLine(bounds.min, bounds.min + Vector3.right * bounds.extents.x * 2, Color.red);
			Debug.DrawLine(bounds.min + Vector3.up * bounds.extents.y * 2, bounds.max, Color.red);
		}

	}
}
