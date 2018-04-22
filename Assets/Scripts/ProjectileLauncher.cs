using UnityEngine;

namespace LD41 {
	public class ProjectileLauncher : MonoBehaviour {

		public GameObject template;

		public float fireRate = 2f;
		public float shootDelay {
			get {
				return 1f / fireRate;
			}
		}

		protected float lastShootTime;

		public void Launch() {
			if (Time.time > lastShootTime + shootDelay) {
				lastShootTime = Time.time;
				ProjectileFactory.CreateProjectile(template, transform.position, transform.rotation.eulerAngles.z);
			}
		}

		private void OnDrawGizmos() {
			Gizmos.DrawRay(transform.position, transform.up);
		}

	}
}
