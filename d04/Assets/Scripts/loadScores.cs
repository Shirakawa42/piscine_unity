using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadScores : MonoBehaviour {

	public Text		rings;
	public Text		lostLifes;
	public Text[]	levels;
	public string[]	levelNames;

	void	Start() {
		rings.text = "Anneaux: " + PlayerPrefs.GetInt("rings", 0);
		lostLifes.text = "Vies perdues: " + PlayerPrefs.GetInt("lostLifes", 0);
		for (int i = 0 ; i < levels.Length ; i++)
		{
			if (PlayerPrefs.GetInt(levelNames[i]) >= 0)
				levels[i].text = "Best Score: " + PlayerPrefs.GetInt(levelNames[i], 0);
		}
	}
}
