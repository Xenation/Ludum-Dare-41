using System.Collections.Generic;
using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.ShootEmUp {
	public class Ship : ShooterEntity, IEventSender {

		public float health = 1f;
		public int scoreGain = 0;
		public float hitBlink = .4f;
		public bool isBlinking = false;
		[ColorUsage(true, true, 0f, 8f, 0.125f, 3f)]
		public Color blinkingColor = Color.white;

		protected List<Weapon> weapons = new List<Weapon>();
		protected SpriteRenderer sprRenderer;
		protected float lastHitTime;

		protected new void Awake() {
			base.Awake();
			GetComponentsInChildren(weapons);
			sprRenderer = GetComponent<SpriteRenderer>();
		}

		protected void Update() {
			if (isBlinking) {
				SetTint(Color.Lerp(Color.white, blinkingColor, GetBlinkValue()));
			}
		}

		protected virtual float GetBlinkValue() {
			float blinkValue = (Time.time - lastHitTime) % (hitBlink * 2f) * 2f;
			if (blinkValue > 1f) {
				blinkValue = 1f - (blinkValue - 1f);
			}
			return blinkValue;
		}
		
		protected void SetTint(Color color) {
			MaterialPropertyBlock props = new MaterialPropertyBlock();
			sprRenderer.GetPropertyBlock(props);
			props.SetColor("_Tint", color);
			sprRenderer.SetPropertyBlock(props);
		}
		
		public void FireAll() {
			foreach(Weapon weapon in weapons) {
				weapon.Fire();
			}
		}

		protected void SetAllWeaponsTarget(Vector3 pos) {
			foreach (Weapon weapon in weapons) {
				weapon.SetGlobalHeading(Vector3.SignedAngle(Vector3.up, pos - transform.position, Vector3.forward));
			}
		}

		protected void OnCollisionEnter2D(Collision2D collision) {
			if (gameObject.layer == LayerUtils.Player) {
				if (collision.gameObject.layer == LayerUtils.EnemyProjectile) {
					Projectile projectile = collision.gameObject.GetComponent<Projectile>();
					ReceiveDamage(projectile.damage);
					projectile.Kill();
				}
			} else if (gameObject.layer == LayerUtils.Enemy) {
				if (collision.gameObject.layer == LayerUtils.PlayerProjectile) {
					Projectile projectile = collision.gameObject.GetComponent<Projectile>();
					Instantiate(Resources.Load("Prefabs/Explosion"), collision.contacts[0].point, Quaternion.identity);
					ReceiveDamage(projectile.damage);
					projectile.Kill();
				}
			}
		}

		public virtual void ReceiveDamage(float dmg) {
			lastHitTime = Time.time;
			health -= dmg;
			if (health <= 0) {
				health = 0f;
				Die();
			}
		}

		public virtual void Die() {
			Destroy(gameObject);
			if(gameObject.tag == "LastShip") {
				GameManager.I.endGame = true;
			}
			this.Send(new ShipKilledEvent(this));
		}

	}
}
