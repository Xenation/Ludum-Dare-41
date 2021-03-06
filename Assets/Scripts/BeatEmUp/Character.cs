﻿using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Character : MonoBehaviour, IEventSender {

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
		protected bool isScaleLocked = false;

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
				if(isScaleLocked == false) {
					if (velocity.x < 0) {
						transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
					} else if (velocity.x > 0) {
						transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
					}
				}
				rb.velocity = velocity;
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
			}
		}

		public virtual void ReceiveDamage(Character inflicter, float damage) {
			health -= damage;
			if (health <= 0) {
				health = 0;
			}
			TriggerOnDamageReceived(inflicter, damage);
			if (health == 0f) {
				Die();
			}
		}

		protected void TriggerOnDamageReceived(Character inflicter, float dmg) {
			if (OnDamageReceivedEvent != null) {
				OnDamageReceivedEvent.Invoke(inflicter);
			}
		}

		protected virtual void DamageReceived(Character ch) {
			isStunned = true;
			stunStartTime = Time.time;
			rb.velocity = Vector2.zero;
			rb.AddForce(-(ch.transform.position - transform.position).normalized * knockForce, ForceMode2D.Impulse);
		}

		public virtual void Die() {
			TriggerOnDeath();
			Destroy(gameObject);
		}

		protected void TriggerOnDeath() {
			if (OnDeathEvent != null) {
				OnDeathEvent.Invoke(this);
			}
		}

	}
}
