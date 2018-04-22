using UnityEngine;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCharacter : Character {

		private Vector2 inputDelta;

		protected void Update() {
			inputDelta = new Vector2(Input.GetAxisRaw("Horizontal Left"), Input.GetAxisRaw("Vertical Left"));
#if UNITY_EDITOR
			manager.mapBounds.DebugDraw();
#endif
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
