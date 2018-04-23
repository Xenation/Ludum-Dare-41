using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerLD41 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadScene(string nextScene) {
		UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
	}

	public void QuitApp() {
		UnityEngine.Application.Quit();
	}
}
