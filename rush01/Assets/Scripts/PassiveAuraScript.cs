using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// need to add an effect

public class PassiveAuraScript : MonoBehaviour {

	private SpellScript	spellscript;
	private GameObject	player;

	void Start () {
		spellscript = GetComponent<IAmASpellScript>().spellscript;
		player = GameObject.Find("Player");
	}
	
	void Update () {
		transform.position = player.transform.position;
	}
}
