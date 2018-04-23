using System.Collections.Generic;
using LD41.Processes;
using UnityEngine;
using Xenon;
using Xenon.Processes;

namespace LD41.BeatEmUp {
	public class WavesManager : Singleton<WavesManager> {

		public EnemyCharacter enemyPrefab;
		public Wave[] waves;

		private ProcessManager procManager = new ProcessManager();
		
		private List<EnemyCharacterSpawnPoint> spawnPoints = new List<EnemyCharacterSpawnPoint>();

		private void Awake() {
			GetComponentsInChildren(spawnPoints);
			BuildWaveProcesses();
		}

		private void BuildWaveProcesses() {
			if (waves.Length == 0) return;
			WaveProcess first = new WaveProcess(waves[0]);
			WaveProcess current = first;
			for (int i = 1; i < waves.Length; i++) {
				TimedProcess delay = new TimedProcess(waves[i - 1].postDelay);
				current.Attach(delay);
				current = new WaveProcess(waves[i]);
				delay.Attach(current);
			}
			procManager.LaunchProcess(first);
		}

		private void Update() {
			procManager.UpdateProcesses(Time.deltaTime);
		}

		public List<EnemyCharacter> SpawnEnemies(int count) {
			if (count < 0) return null;
			List<EnemyCharacter> enemiesSpawned = new List<EnemyCharacter>();
			int index = 0;
			while (count != 0) {
				enemiesSpawned.Add(spawnPoints[index].SpawnEnemy(enemyPrefab));
				index = (index + 1) % spawnPoints.Count;
				count--;
			}
			return enemiesSpawned;
		}

		public void OnWaveEnd(Wave wave) {
			Debug.Log("BeatEmUp: Wave Ended");
		}

	}
}
