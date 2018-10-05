using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dataSelectButtons : MonoBehaviour {

	public string		sceneName;

	public void		goToLevel() {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
