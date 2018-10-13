using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTreeTakeSpell : MonoBehaviour {

	public int					placement;
	private SpellScript			spellscript;
	public PlayerSpellScript	player;

	void Start () {
		spellscript = transform.parent.GetComponent<TalentUpgradeScript>().spellscript;
	}

	public void Equip() {
		if (spellscript.level > 0) {
			player.spells[placement] = spellscript;
			GameObject spell = GameObject.Find("spell" + (placement + 1));
			spell.GetComponent<Image>().sprite = spellscript.sprite;
			spell.GetComponent<SpellIconsScript>().spellscript = spellscript;
		}
	}
}
