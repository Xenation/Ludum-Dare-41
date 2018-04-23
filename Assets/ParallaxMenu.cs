using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour {

	public float moveSpeed = 0.01f;
	void FixedUpdate() {
		transform.position = new Vector3(transform.position.x, transform.position.y+moveSpeed*Time.fixedDeltaTime, transform.position.z);
	}
}
