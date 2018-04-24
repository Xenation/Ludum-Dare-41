using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD41.BeatEmUp {
	public class ReleasePlayer : MonoBehaviour {

		public void FreePlayer() {
			GameObject player;
			player = GameObject.FindGameObjectWithTag("Player");
			player.transform.SetParent(null);
			player.GetComponent<PlayerCharacter>().enabled = true;
			player.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}