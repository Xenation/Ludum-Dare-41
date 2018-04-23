using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCharacter : Character {

		private Vector2 inputDelta;
		private Animator anim;
		private int atkStateShort = Animator.StringToHash("Attack");

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
				anim.SetTrigger(atkStateShort);
			}
		}

		protected new void FixedUpdate() {
			if (!isStunned) {
				velocity = new Vector2(inputDelta.x, inputDelta.y);
				velocity.Normalize();
				velocity *= speed;
				manager.mapBounds.KeepVelocityInBounds(transform.position, ref velocity, Time.fixedDeltaTime);
			}

			isScaleLocked = (anim.GetCurrentAnimatorStateInfo(1).shortNameHash == atkStateShort);

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
