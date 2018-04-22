using UnityEngine;

namespace LD41 {
	public class MovingEntity : MonoBehaviour {

		public float speed;
		
		public Vector2 velocity;

		protected MapBounds bounds;

		protected void FixedUpdate() {
			transform.position += (Vector3) velocity * Time.fixedDeltaTime;
		}

	}
}
