using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41.ShootEmUp {
	[RequireComponent(typeof(SpriteRenderer))]
	public class ShipController : Ship {

		public float invincibilityTime = 3f;

		private Vector2 inputDelta;
		

		protected new void Awake() {
			base.Awake();
		}

		private new void Update() {
			inputDelta = new Vector2(Input.GetAxisRaw("Horizontal Right"), Input.GetAxisRaw("Vertical Right"));

			base.Update();

			if (Input.GetButton("Fire1")) {
				FireAll();
			}

			if (Time.time > lastHitTime + invincibilityTime) {
				isBlinking = false;
				SetTint(Color.white);
			}
		}

		protected new void FixedUpdate() {
			velocity = new Vector2(inputDelta.x, inputDelta.y);
			velocity.Normalize();
			velocity *= speed;
			manager.mapBounds.KeepVelocityInBounds(transform.position, ref velocity, Time.fixedDeltaTime);
			base.FixedUpdate();
		}

		public override void ReceiveDamage(float dmg) {
			if (!isBlinking) {
				isBlinking = true;
				base.ReceiveDamage(dmg);
			}
		}

	}
}
