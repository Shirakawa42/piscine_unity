using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreenButtons : MonoBehaviour {

	public string[]		levelNames;

	public void		resetPlayerPrefs() {
		PlayerPrefs.SetInt("rings", 0);
		PlayerPrefs.SetInt("lostLifes", 0);
		foreach (string name in levelNames)
			PlayerPrefs.SetInt(name, -1);
		PlayerPrefs.SetInt(levelNames[0], 0);
		PlayerPrefs.Save();
	}

	public void		goToDataSelect() {
		SceneManager.LoadScene("DataSelect", LoadSceneMode.Single);
	}
}
