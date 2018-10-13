using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraScript : MonoBehaviour {

	private SpellScript		spellscript;
	private GameObject 		player;
	private List<Collider>	colliders;

	void Start () {
		spellscript = GetComponent<IAmASpellScript>().spellscript;
		player = GameObject.Find("Player");
		dealDamages();
		Invoke("Die", 10.0f);
	}

	void Die () {
		Destroy(gameObject);
	}

	void dealDamages () {
		if (colliders != null) {
			foreach (Collider collider in colliders) {
				Debug.Log("Damaging " + collider + "for " + spellscript.Damages + "damages");
			}
		}
		Invoke("dealDamages", 0.25f);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "enemy")
			colliders.Add(other);
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "enemy")
			colliders.Remove(other);
	}
	
	void Update () {
		transform.position = player.transform.position;
	}
}
