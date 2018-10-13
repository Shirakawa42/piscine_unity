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
	public Sprite		sprite;
	public string		description;
	public int 			damagePerLevel;
	public int 			level;

	private bool 		canCast = true;
	private GameObject 	cpy;

	public void		levelUp() {
		Damages += damagePerLevel;
		level++;
	}

	void Start () {
		canCast = true;
	}

	public void 	cast (Vector3 position, Quaternion rotation) {
		if (canCast && !requierClic) {
			cpy = Instantiate(SpellPrefab, position, rotation);
			cpy.GetComponent<IAmASpellScript>().spellscript = this;
			canCast = false;
			Invoke("SetCanCast", Cooldown);
		}
		else if (canCast && requierClic) {
			cpy = Instantiate(Splat);
			cpy.GetComponent<SplatScript>().spellscript = this;
			canCast = false;
		}
	}

	public void 	splatCast (Vector3 position, Quaternion rotation) {
		cpy = Instantiate(SpellPrefab, position, rotation);
		cpy.GetComponent<IAmASpellScript>().spellscript = this;
		Invoke("SetCanCast", Cooldown);
	}

	public bool Usage () {
		if (passive)
			return false;
		return true;
	}

	void	SetCanCast () {
		canCast = true;
	}
}
