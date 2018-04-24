using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHat : MonoBehaviour {

	void Start () {
		Sprite[] sprite = Resources.LoadAll<Sprite>("HatMan");
		Debug.Log(sprite.Length);
		this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(1, sprite.Length)];
	}

}
