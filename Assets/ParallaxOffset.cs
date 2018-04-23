using UnityEngine;

public class ParallaxOffset : MonoBehaviour {

	public float parallaxOffset = 1;
	public string mapTag = "Map";
	private Transform map;
	
	void Start () {
		map = GameObject.FindGameObjectWithTag(mapTag).transform;
	}
	
	void Update () {

		if(mapTag == "Map_Beat") {
			transform.position = new Vector3(map.position.y*parallaxOffset, 0, transform.position.z);
		} else {
			transform.position = new Vector3(0, map.position.y*parallaxOffset, transform.position.z);
		}
	}
}
