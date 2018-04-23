using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCharacter : Character {

		private Vector2 inputDelta;

		protected void Update() {
			inputDelta = new Vector2(Input.GetAxisRaw("Horizontal Left"), Input.GetAxisRaw("Vertical Left"));
#if UNITY_EDITOR
			manager.mapBounds.DebugDraw();
#endif

			if (Input.GetButtonDown("Fire1")) {
				melee.Hit();
			}
		}

		protected new void FixedUpdate() {
			if (!isStunned) {
				velocity = new Vector2(inputDelta.x, inputDelta.y);
				velocity.Normalize();
				velocity *= speed;
				manager.mapBounds.KeepVelocityInBounds(transform.position, ref velocity, Time.fixedDeltaTime);
			}
			base.FixedUpdate();
		}

		public override void ReceiveDamage(Character inflicter, float dmg) {
			base.ReceiveDamage(inflicter, dmg);
			this.Send(new PlayerCharacterDamagedEvent(this, dmg));
		}

		public override void Die() {
			TriggerOnDeath();
			this.Send(new PlayerCharacterDeathEvent(this));
		}

	}
}
