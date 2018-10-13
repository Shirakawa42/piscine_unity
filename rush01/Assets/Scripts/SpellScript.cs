using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

	public GameObject	SpellPrefab;
	public GameObject 	Splat;
	public float		manaCost;
	public float		Cooldown;
	public int 			Damages;
	public bool			passive;
	public bool 		requierClic;

	private bool 		canCast = true;

	public void 	cast (Vector3 position, Quaternion rotation) {
		if (canCast && !requierClic) {
			Instantiate(SpellPrefab, position, rotation);
			canCast = false;
			Invoke("SetCanCast", Cooldown);
		}
		else if (canCast && requierClic) {
			GameObject cpy = Instantiate(Splat, position, rotation);
			cpy.GetComponent<SplatScript>().spellscript = this;
			canCast = false;
		}
	}

	public bool Usage () {
		if (passive)
			return false;
		return true;
	}

	void Start () {
		canCast = true;
	}

	void	SetCanCast () {
		canCast = true;
	}
}
