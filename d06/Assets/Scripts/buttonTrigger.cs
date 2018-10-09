using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTrigger : MonoBehaviour {

	public ParticleSystem 	PS;
	public lightTrigger 	LT;
	public AudioSource 		AS;
	private bool 			triggered = false;

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && Input.GetKeyDown("e") && !triggered) {
			PS.Play();
			LT.isCloud = true;
			AS.Play();
			triggered = true;
		}
	}
}
