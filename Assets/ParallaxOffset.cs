using UnityEngine;

public class ParallaxOffset : MonoBehaviour {

	public float parallaxOffset = 1;
	private Transform map;
	
	void Start () {
		map = GameObject.FindGameObjectWithTag("Map").transform;
	}
	
	void Update () {
		transform.position = map.position*parallaxOffset;
	}
}
