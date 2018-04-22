using UnityEngine;
using Xenon;

namespace LD41.ShootEmUp {
	public class TriggersManager : Singleton<TriggersManager> {

		public BoxCollider2D top;
		public BoxCollider2D rightHigh;
		public BoxCollider2D rightMiddle;
		public BoxCollider2D rightLow;
		public BoxCollider2D leftHigh;
		public BoxCollider2D leftMiddle;
		public BoxCollider2D leftLow;

		public float highRatio = .8f;
		public float middleRatio = .6f;
		public float lowRatio = .4f;

		public void Initialize(Bounds bounds) {
			top.transform.position = new Vector3(0, bounds.extents.y + 1);
			top.size = new Vector2(bounds.size.x, 1f);

			rightHigh.transform.position = new Vector3(bounds.size.x, -bounds.extents.y + bounds.size.y * highRatio);
			rightHigh.size = new Vector2(bounds.size.x, 1f);
			rightMiddle.transform.position = new Vector3(bounds.size.x, -bounds.extents.y + bounds.size.y * middleRatio);
			rightMiddle.size = new Vector2(bounds.size.x, 1f);
			rightLow.transform.position = new Vector3(bounds.size.x, -bounds.extents.y + bounds.size.y * lowRatio);
			rightLow.size = new Vector2(bounds.size.x, 1f);

			leftHigh.transform.position = new Vector3(-bounds.size.x, -bounds.extents.y + bounds.size.y * highRatio);
			leftHigh.size = new Vector2(bounds.size.x, 1f);
			leftMiddle.transform.position = new Vector3(-bounds.size.x, -bounds.extents.y + bounds.size.y * middleRatio);
			leftMiddle.size = new Vector2(bounds.size.x, 1f);
			leftLow.transform.position = new Vector3(-bounds.size.x, -bounds.extents.y + bounds.size.y * lowRatio);
			leftLow.size = new Vector2(bounds.size.x, 1f);
		}

		public Collider2D GetTrigger(SpawnTriggerType t, float side = 0f) {
			switch (t) {
				case SpawnTriggerType.Top:
					return top;
				case SpawnTriggerType.SideHigh:
					if (side > 0f) {
						return rightHigh;
					} else if (side < 0f) {
						return leftHigh;
					}
					return null;
				case SpawnTriggerType.SideMiddle:
					if (side > 0f) {
						return rightMiddle;
					} else if (side < 0f) {
						return leftMiddle;
					}
					return null;
				case SpawnTriggerType.SideLow:
					if (side > 0f) {
						return rightLow;
					} else if (side < 0f) {
						return leftLow;
					}
					return null;
				default:
					return null;
			}
		}

	}
}
