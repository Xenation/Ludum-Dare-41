using UnityEngine;

namespace LD41.BeatEmUp {
	public class EnemyCharacterSpawnPoint : MonoBehaviour {

		public EnemyCharacter SpawnEnemy(EnemyCharacter prefab) {
			GameObject go = Instantiate(prefab.gameObject, transform.position, Quaternion.identity);
			go.transform.SetParent(BeatEmUpManager.I.enemiesRoot);
			return go.GetComponent<EnemyCharacter>();
		}

	}
}
