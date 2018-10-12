using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	public bool 	isAOE;
	public int		damages;

	private bool	done = false;

	void OnTriggerEnter (Collider other) {
		if ((other.tag == "enemy" || other.tag == "Enemy") && !done) {
			if (!isAOE)
				done = true;
			other.GetComponent<UnitScript>().takeDamages(damages);
		}
	}
}
