using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41 {
	public class ShipController : Ship {
		
		private Vector2 inputDelta;

		protected new void Awake() {
			base.Awake();
		}

		private void Update() {
			inputDelta = new Vector2(Input.GetAxisRaw("Horizontal Right"), Input.GetAxisRaw("Vertical Right"));
#if UNITY_EDITOR
			manager.mapBounds.DebugDraw();
#endif

			if (Input.GetButton("Fire1")) {
				FireAll();
			}
		}

		protected new void FixedUpdate() {
			velocity = new Vector2(inputDelta.x, inputDelta.y);
			velocity.Normalize();
			velocity *= speed;
			manager.mapBounds.KeepVelocityInBounds(transform.position, ref velocity, Time.fixedDeltaTime);
			base.FixedUpdate();
		}

	}
}
