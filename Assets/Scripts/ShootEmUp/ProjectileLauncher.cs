using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.ShootEmUp {
	public class ProjectileLauncher : MonoBehaviour, IEventSender {

		public GameObject template;

		public float fireRate = 2f;
		public float shootDelay {
			get {
				return 1f / fireRate;
			}
		}

		[System.NonSerialized]
		public Weapon weapon;

		protected float lastShootTime;

		public void Launch() {
			if (Time.time > lastShootTime + shootDelay) {
				lastShootTime = Time.time;
				this.Send(new LauncherFiringEvent(this));
				ProjectileFactory.CreateProjectile(template, transform.position, transform.rotation.eulerAngles.z);
			}
		}

		private void OnDrawGizmos() {
			Gizmos.DrawRay(transform.position, transform.up);
		}

	}
}
