using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour {

	public bool 		hasCard = false;
	public GameObject 	door;
	private int 		triggered;

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && hasCard && Input.GetKeyDown("e") && triggered == 0) {
			door.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler (0, -90, 0), Time.deltaTime * 90.0f);
			triggered++;
			GetComponent<AudioSource>().Play();
		}
	}
}
