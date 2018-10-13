using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellIconsScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public SpellScript 	spellscript;
	public Image		spelldescriptor;
	public Text			spelltext;
	public bool 		top = true;

	public void OnPointerEnter (PointerEventData eventData) {
		if (spellscript != null) {
			spelldescriptor.gameObject.SetActive(true);
			if (top)
				spelldescriptor.transform.position = transform.position + new Vector3(0, 200, 0);
			else
				spelldescriptor.transform.position = transform.position + new Vector3(0, -200, 0);
			spelltext.text = spellscript.description + "\nEffect power: " + spellscript.Damages + "\nNext Level Effect power: " 
				+ (spellscript.Damages + spellscript.damagePerLevel) + "\nCurrent Level: " + spellscript.level;
		}
	}

	public void OnPointerExit (PointerEventData eventData) {
		spelldescriptor.gameObject.SetActive(false);
	}
}
