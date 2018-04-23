using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLD41 : MonoBehaviour {

	private void Awake() {
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnSceneLoad;
	}

	private void OnSceneLoad(Scene scene, LoadSceneMode loadMode) {
		Time.timeScale = 1f;
	}

	public void LoadScene(string nextScene) {
		SceneManager.LoadScene(nextScene);
	}

	public void QuitApp() {
		Application.Quit();
	}

}
