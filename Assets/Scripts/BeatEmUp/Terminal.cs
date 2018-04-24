using LD41.ShootEmUp;
using UnityEngine;

namespace LD41.BeatEmUp {
	public class Terminal : MonoBehaviour {

		private Animator anim;

		public ProjectileLauncher linkedLauncher;
		[System.NonSerialized]
		public bool isEnabled = true;

		public void Awake() {
			anim = GetComponentInChildren<Animator>();
			BeatEmUpManager.I.terminals.Add(this);
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
		}

		public void DisableTerminal() {
			anim.SetBool("IsAlert", true);
			isEnabled = false;
			linkedLauncher.canShoot = false;
		}

		public void EnableTerminal() {
			anim.SetBool("IsAlert", false);
			isEnabled = true;
			linkedLauncher.canShoot = true;
		}

	}
}
