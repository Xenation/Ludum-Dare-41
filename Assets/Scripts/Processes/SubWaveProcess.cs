using LD41.BeatEmUp;
using Xenon.Processes;

namespace LD41.Processes {
	public class SubWaveProcess : TimedProcess {

		public SubWave subWave;
		private WaveProcess parent;

		public SubWaveProcess(SubWave subWave, WaveProcess parent) : base(subWave.postDelay) {
			this.subWave = subWave;
			this.parent = parent;
		}

		public override void OnBegin() {
			base.OnBegin();
			parent.AddEnemiesAlive(WavesManager.I.SpawnEnemies(subWave.enemyCount));
		}

	}
}
