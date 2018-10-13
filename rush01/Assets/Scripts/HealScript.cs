using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {

	private SpellScript	spellscript;
	private GameObject	player;

	void Die () {
		Destroy(gameObject);
	}

	void Start () {
		spellscript = GetComponent<IAmASpellScript>().spellscript;
		player = GameObject.Find("Player");
		Debug.Log("Healing the player for " + spellscript.Damages + "HP !");
		Invoke("Die", 3.0f);
	}
	
	void Update () {
		transform.position = player.transform.position;
	}
}
