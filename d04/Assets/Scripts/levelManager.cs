using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour {

	public GameObject[]	levelButtons;

	void Start() {
		foreach (GameObject button in levelButtons)
		{
			if (PlayerPrefs.GetInt(button.GetComponentInChildren<Text>().text, 0) < 0)
				button.GetComponent<Button>().interactable = false;
			else
				button.GetComponent<Button>().interactable = true;
		}
	}
}
