using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public float destroyTime = 1;

	void Start() {
		Destroy(this.gameObject, destroyTime);
	}
}
