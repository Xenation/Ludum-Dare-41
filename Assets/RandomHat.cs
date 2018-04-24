using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHat : MonoBehaviour {

	public Sprite[] sprite;
	public float percentHat = 0.2f;

	void Start () {
		if(percentHat > Random.Range(0f,1f)) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite[Random.Range(0, sprite.Length)];
		}
	}

}
