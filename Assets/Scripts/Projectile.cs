using UnityEngine;

namespace LD41 {
	[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
	public class Projectile : ShooterEntity {
		
		public float damage;
		public GameObject Template { get; private set; }
		
		protected SpriteRenderer spriteRenderer;

		protected new void Awake() {
			base.Awake();
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Initialize(GameObject template, Vector2 pos, float heading) {
			Template = template;
			Projectile templateProjectile = Template.GetComponent<Projectile>();
			SpriteRenderer templateSpriteRenderer = Template.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = templateSpriteRenderer.sprite;
			speed = templateProjectile.speed;
			damage = templateProjectile.damage;
			transform.position = pos;
			transform.rotation = Quaternion.Euler(0, 0, heading);
			velocity = transform.up.normalized * speed;
		}

		protected new void FixedUpdate() {
			base.FixedUpdate();
			if (!bounds.IsInBounds(transform.position, 1f)) {
				Kill();
			}
		}

		public void Kill() {
			ProjectileFactory.BuryProjectile(this);
		}

	}
}
