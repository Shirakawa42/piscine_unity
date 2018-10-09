using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {

	public AudioSource 		normal;
	public AudioSource		epic;
	public discretionBar 	dB;
	private bool 			actualNormal;

	void Update () {
		if (dB.progressBar.fillAmount >= 0.75f && actualNormal)
		{
			normal.Stop();
			epic.Play();
			actualNormal = false;
		}
		else if (dB.progressBar.fillAmount < 0.75f && !actualNormal)
		{
			epic.Stop();
			normal.Play();
			actualNormal = true;
		}
	}
}
