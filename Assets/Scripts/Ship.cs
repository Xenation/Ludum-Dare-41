using System.Collections.Generic;
using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41 {
	public class Ship : ShooterEntity, IEventSender {

		public float health = 1f;
		public int scoreGain = 0;

		protected List<Weapon> weapons = new List<Weapon>();

		protected new void Awake() {
			base.Awake();
			GetComponentsInChildren(weapons);
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
					ReceiveDamage(projectile.damage);
					projectile.Kill();
				}
			}
		}

		public void ReceiveDamage(float dmg) {
			health -= dmg;
			if (health < 0) {
				health = 0f;
				Die();
			}
		}

		public virtual void Die() {
			Destroy(gameObject);
			this.Send(new ShipKilledEvent(this));
		}

	}
}
