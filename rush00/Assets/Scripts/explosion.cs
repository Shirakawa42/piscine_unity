using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player")
		{
			Debug.Log("killed");
			// kill player
		}
		else if (other.tag == "Enemy")
		{
			// kill enemy
		}
		else if (other.tag == "DOOR")
		{
			Destroy(other.gameObject);
		}
	}

	void Die () {
		Destroy(this.gameObject);
	}
	
	void Update () {
		Invoke("Die", 0.75f);
	}
}
