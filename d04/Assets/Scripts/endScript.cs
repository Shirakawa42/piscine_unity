using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScript : MonoBehaviour {

	public	GameObject	canvas;
	public	Text		cText;
	public	gameUI		gUI;
	public	AudioSource	music;
	private bool		actived;

	void Start() {
		actived = false;
		canvas.SetActive(false);
	}

	void showScore() {
		canvas.SetActive(true);
		cText.text = "Score: " + gUI.realScore;
		if (PlayerPrefs.GetInt("Level 1", 0) < gUI.realScore)
		{
			PlayerPrefs.SetInt("Level 1", gUI.realScore);
			PlayerPrefs.Save();
		}
		Destroy(this);
	}
	
	void OnTriggerEnter2D( Collider2D other ) {
		if (!actived)
		{
			actived = true;
			GetComponent<AudioSource>().Play();
			Invoke("showScore", 6);
			music.mute = true;
		}
	}
}
