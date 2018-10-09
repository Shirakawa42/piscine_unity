using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardTrigger : MonoBehaviour {

	public doorTrigger 	DT;
	public AudioSource 	audiosource;

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && Input.GetKeyDown("e")) {
			DT.hasCard = true;
			audiosource.Play();
			Destroy(transform.parent.gameObject);
		}
	}
}
