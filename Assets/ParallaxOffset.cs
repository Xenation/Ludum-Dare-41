using UnityEngine;

public class ParallaxOffset : MonoBehaviour {

	public float parallaxOffset = 1;
	private Transform map;
	
	void Start () {
		map = GameObject.FindGameObjectWithTag("Map").transform;
	}
	
	void Update () {
		transform.position = new Vector3(transform.position.x, map.position.y*parallaxOffset, transform.position.z);
	}
}
