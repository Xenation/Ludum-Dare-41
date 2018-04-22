using System.Collections.Generic;
using UnityEngine;

namespace LD41.ShootEmUp {
	public static class ProjectileFactory {

		private static GameManager gameManager;
		private static Transform projectilesStorage;
		
		private static Dictionary<GameObject, Queue<Projectile>> projectileCimetary = new Dictionary<GameObject, Queue<Projectile>>();

		static ProjectileFactory() {
			gameManager = GameManager.I;
			projectilesStorage = new GameObject("ProjectilesStorage").transform;
			projectilesStorage.SetParent(gameManager.transform, false);
		}

		public static Projectile CreateProjectile(GameObject template, Vector2 pos, float heading) {
			Projectile projectile;
			Queue<Projectile> grave = GetOrCreateGrave(template);
			if (grave.Count == 0) { // Create new projectile
				GameObject go = Object.Instantiate(template);
				go.transform.SetParent(projectilesStorage);
				projectile = go.GetComponent<Projectile>();
				projectile.Initialize(template, pos, heading);
			} else { // Revive from grave
				projectile = grave.Dequeue();
				projectile.gameObject.SetActive(true);
				projectile.gameObject.layer = template.layer;
				projectile.Initialize(template, pos, heading);
			}
			return projectile;
		}

		private static Queue<Projectile> GetOrCreateGrave(GameObject template) {
			Queue<Projectile> grave;
			if (!projectileCimetary.TryGetValue(template, out grave)) {
				grave = new Queue<Projectile>();
				projectileCimetary.Add(template, grave);
			}
			return grave;
		}

		public static void BuryProjectile(Projectile projectile) {
			projectile.gameObject.SetActive(false);
			Queue<Projectile> grave = GetOrCreateGrave(projectile.Template);
			grave.Enqueue(projectile);
		}

	}
}
