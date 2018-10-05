using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initPlayerPrefs : MonoBehaviour {

	public string[]		levelNames;

	void Start () {
		if (!PlayerPrefs.HasKey("rings"))
			PlayerPrefs.SetInt("rings", 0);
		if (!PlayerPrefs.HasKey("lostLifes"))
			PlayerPrefs.SetInt("lostLifes", 0);
		foreach (string name in levelNames)
		{
			if (!PlayerPrefs.HasKey(name))
				PlayerPrefs.SetInt(name, -1);
		}
		if (PlayerPrefs.GetInt(levelNames[0], -1) == -1)
			PlayerPrefs.SetInt(levelNames[0], 0);
		PlayerPrefs.Save();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene("DataSelect", LoadSceneMode.Single);
		}
	}
}
