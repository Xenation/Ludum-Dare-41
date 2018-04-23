using UnityEngine;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Character : MonoBehaviour {

		public delegate void OnDamageReceived(Character dmgDealer);
		public event OnDamageReceived OnDamageReceivedEvent;

		public delegate void OnDeath(Character died);
		public event OnDeath OnDeathEvent;

		public float speed = 4f;
		public float health = 5f;
		public float stunTime = 1f;
		public float knockForce = 2f;

		protected Rigidbody2D rb;
		protected Vector2 velocity;
		protected MeleeController melee;

		protected BeatEmUpManager manager;
		protected MapBounds bounds;

		private Vector3 startScale;
		protected bool isStunned = false;
		protected float stunStartTime;

		protected void Awake() {
			rb = GetComponent<Rigidbody2D>();
			melee = GetComponentInChildren<MeleeController>();
			manager = BeatEmUpManager.I;
			bounds = manager.mapBounds;
			startScale = transform.localScale;
			OnDamageReceivedEvent += DamageReceived;
		}

		protected void FixedUpdate() {
			if (isStunned) {
				if (Time.time > stunStartTime + stunTime) {
					isStunned = false;
				}
			} else {
				if (velocity.x < 0) {
					transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
				} else if (velocity.x > 0) {
					transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
				}
				rb.velocity = velocity;
			}
		}

		public void ReceiveDamage(Character ch, float damage) {
			health -= damage;
			if (health <= 0) {
				health = 0;
				Die();
			}
			if (OnDamageReceivedEvent != null) {
				OnDamageReceivedEvent.Invoke(ch);
			}
		}

		protected void DamageReceived(Character ch) {
			isStunned = true;
			stunStartTime = Time.time;
			rb.velocity = Vector2.zero;
			rb.AddForce(-(ch.transform.position - transform.position).normalized * knockForce, ForceMode2D.Impulse);
		}

		public void Die() {
			if (OnDeathEvent != null) {
				OnDeathEvent.Invoke(this);
			}
			Destroy(gameObject);
		}

	}
}
