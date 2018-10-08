using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeTriggerScript : MonoBehaviour {

	public float	x;
	public float 	y;
	public float	z;
	public int 		nb;
	public holeController 	controller;

	void OnTriggerStay(Collider other) {
		if (other.tag == "ball" && Input.GetKeyDown(KeyCode.Return)) {
			if (controller.isGood(nb))
				other.transform.position = new Vector3(x, y, z);
		}
	}
}
