using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightTrigger : MonoBehaviour {

	public Image			progressBar;
	public discretionBar 	dB;
	public bool 			isCamera;
	public bool 			isCloud = false;

	void 	OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			dB.trigger = false;
			if (isCamera)
				dB.camera = 1.0f;
		}
	}

	void	OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			dB.trigger = true;
			if (isCamera && !isCloud)
				dB.camera = 5.0f;
			else if (isCamera && isCloud)
				dB.camera = 0.5f;
		}
	}
}
