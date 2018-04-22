using UnityEngine;

namespace LD41.ShootEmUp {
	public abstract class StayingMover : EnemyMover {

		public float maxStayTime = 0f;

		protected float stayStartTime;
		protected bool isLeaving = false;

		protected void OnEnable() {
			stayStartTime = Time.time;
		}

		protected void Update() {
			if (maxStayTime != 0f && Time.time > stayStartTime + maxStayTime) {
				isLeaving = true;
			}
		}

	}
}
