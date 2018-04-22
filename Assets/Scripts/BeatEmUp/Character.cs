using UnityEngine;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(Rigidbody2D))]
	public class Character : MonoBehaviour {

		public float speed = 4f;
		public float health = 5f;

		protected Rigidbody2D rb;
		protected Vector2 velocity;

		protected BeatEmUpManager manager;
		protected MapBounds bounds;

		protected void Awake() {
			rb = GetComponent<Rigidbody2D>();
			manager = BeatEmUpManager.I;
			bounds = manager.mapBounds;
		}

		protected void FixedUpdate() {
			rb.velocity = velocity;
		}

	}
}
