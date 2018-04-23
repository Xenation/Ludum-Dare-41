﻿using UnityEngine;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCharacter : Character {

		private Vector2 inputDelta;
		private Animator anim;

		protected new void Awake() {
			base.Awake();
			anim = GetComponent<Animator>();
		}

		protected void Update() {
			inputDelta = new Vector2(Input.GetAxisRaw("Horizontal Left"), Input.GetAxisRaw("Vertical Left"));
#if UNITY_EDITOR
			manager.mapBounds.DebugDraw();
#endif

			if (Input.GetButtonDown("Fire1")) {
				melee.Hit();
				anim.SetTrigger("Attack");
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

	}
}
