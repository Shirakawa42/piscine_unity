using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagesScript : MonoBehaviour {

	public float	CD;
	private bool 	canAttack = true;
	public int 		damages;

	void SetCanAttack () {
		canAttack = true;
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player" && canAttack) {
			other.transform.GetChild(0).GetComponent<PlayerScript>().takeDamages(damages);
			canAttack = false;
			Invoke("SetCanAttack", CD);
		}
	}
}
