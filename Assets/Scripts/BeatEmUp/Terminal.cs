using LD41.ShootEmUp;
using UnityEngine;

namespace LD41.BeatEmUp {
	public class Terminal : MonoBehaviour {

		public ProjectileLauncher linkedLauncher;
		[System.NonSerialized]
		public bool isEnabled = true;

		public void Awake() {
			BeatEmUpManager.I.terminals.Add(this);
		}

		public void DisableTerminal() {
			isEnabled = false;
			linkedLauncher.canShoot = false;
		}

		public void EnableTerminal() {
			isEnabled = true;
			linkedLauncher.canShoot = true;
		}

	}
}
