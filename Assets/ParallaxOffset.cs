using UnityEngine;

public class ParallaxOffset : MonoBehaviour {

	public float parallaxOffset = 1;
	public string tag = "Map";
	private Transform map;
	
	void Start () {
		map = GameObject.FindGameObjectWithTag(tag).transform;
	}
	
	void Update () {
		if(tag == "Map_Beat") {
			transform.position = new Vector3(map.position.y*parallaxOffset, 0, transform.position.z);
		} else {
			transform.position = new Vector3(0, map.position.y*parallaxOffset, transform.position.z);
		}
	}
}
