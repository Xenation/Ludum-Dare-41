using System.Collections.Generic;
using LD41.BeatEmUp;
using Xenon;
using Xenon.Processes;

namespace LD41.Processes {
	public class WaveProcess : CompositeProcess {

		public Wave wave;
		public List<EnemyCharacter> enemiesAlive = new List<EnemyCharacter>();

		public WaveProcess(Wave wave) : base() {
			this.wave = wave;
			foreach (SubWave subWave in wave.subWaves) {
				AddProcess(new SubWaveProcess(subWave, this));
			}
		}

		public override void OnTerminate() {
			base.OnTerminate();
			WavesManager.I.OnWaveEnd(wave);
		}

		protected override void OnLastProcessEnded() {
			
		}

		public void AddEnemiesAlive(List<EnemyCharacter> enemies) {
			enemiesAlive.AddRange(enemies);
			foreach (EnemyCharacter enemy in enemies) {
				enemy.OnDeathEvent += OnSpawnedEnemyDeath;
			}
		}

		private void OnSpawnedEnemyDeath(Character ch) {
			EnemyCharacter enemy = ch as EnemyCharacter;
			if (enemy == null) return;
			enemiesAlive.Remove(enemy);
			if (enemiesAlive.Count == 0) {
				Terminate();
			}
		}

	}
}
