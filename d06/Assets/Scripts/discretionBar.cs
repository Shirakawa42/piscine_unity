using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class discretionBar : MonoBehaviour {

	public FirstPersonController	player;
	public Image					progressBar;
	public AudioSource 				audio;
	private bool					audioLaunched = false;
	public bool 					trigger;
	public float 					camera = 1.0f;
	
	void Update () {
		if ((!player.m_IsWalking && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))) || trigger)
			progressBar.fillAmount += 0.4f * Time.deltaTime * camera;
		else if (!trigger)
			progressBar.fillAmount -= 0.2f * Time.deltaTime;
		if (progressBar.fillAmount >= 0.75f && !audioLaunched)
		{
			audio.Play();
			audioLaunched = true;
		}
		else if (progressBar.fillAmount < 0.75f && audioLaunched)
		{
			audioLaunched = false;
			audio.Stop();
		}
		if (progressBar.fillAmount >= 1.0f)
			SceneManager.LoadScene("ex00");
	}
}
