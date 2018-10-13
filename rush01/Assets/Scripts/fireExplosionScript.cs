using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExplosionScript : MonoBehaviour {

	private SpellScript	spellscript;

	void Die () {
		Destroy(gameObject);
	}

	void Start () {
		spellscript = GetComponent<IAmASpellScript>().spellscript;
		Invoke("Die", 0.8f);
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "enemy") {
			Debug.Log("Damaging " + other + ", dealing " + spellscript.Damages + " damages !");
		}		
	}
}
