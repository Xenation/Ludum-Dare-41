using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class EnemyCharacter : Character {

		public enum State {
			Nominal,
			ReachingTarget,
			WaitingToHit,
			Hitting,
		}

		public float minDistance = .7f;
		public float slowDistance = 2f;
		public float hitRange = 1f;
		public float hitTerminalDelay = 2f;
		public float stayAtTerminalTime = 3f;

		protected bool isTargetingPlayer = false;
		protected PlayerCharacter playerChar;
		protected Transform target;
		protected float targetActionStartTime;
		protected State state = State.Nominal;

		protected new void Awake() {
			base.Awake();
			playerChar = manager.playerChar;
		}
		
		protected new void FixedUpdate() {
			if (!isStunned) {
				Vector2 toTarget = Vector2.zero;
				if (target != null) {
					toTarget = target.position - transform.position;
					velocity = toTarget.RemapMagnitude(minDistance, slowDistance, 0f, speed).ClampMagnitude(0, speed);
				}
				if (isTargetingPlayer) {
					switch (state) {
						case State.Nominal:
							target = playerChar.transform;
							state = State.ReachingTarget;
							break;
						case State.ReachingTarget:
							if (toTarget.magnitude < hitRange) {
								state = State.Hitting;
							}
							break;
						case State.Hitting:
							melee.Hit();
							if (toTarget.magnitude > hitRange) {
								state = State.ReachingTarget;
							}
							break;
					}
				} else {
					switch (state) {
						case State.Nominal:
							Terminal terminal = manager.GetClosestEnabledTerminal(transform.position);
							if (terminal == null) {
								isTargetingPlayer = true;
								target = playerChar.transform;
							} else {
								target = terminal.transform;
								state = State.ReachingTarget;
							}
							break;
						case State.ReachingTarget:
							if (toTarget.magnitude < hitRange) {
								targetActionStartTime = Time.time;
								state = State.WaitingToHit;
							}
							break;
						case State.WaitingToHit:
							if (Time.time > targetActionStartTime + hitTerminalDelay) {
								targetActionStartTime = Time.time;
								state = State.Hitting;
							}
							break;
						case State.Hitting:
							if (Time.time > targetActionStartTime + stayAtTerminalTime) {
								state = State.Nominal;
							} else {
								melee.Hit();
							}
							break;
					}
				}
			}
			
			base.FixedUpdate();
		}

		public override void ReceiveDamage(Character inflicter, float damage) {
			base.ReceiveDamage(inflicter, damage);
			isTargetingPlayer = true;
			state = State.Nominal;
			this.Send(new EnemyCharacterDamagedEvent(this, inflicter, damage));
		}

		public override void Die() {
			base.Die();
			this.Send(new EnemyCharacterDeathEvent(this));
		}

	}
}
