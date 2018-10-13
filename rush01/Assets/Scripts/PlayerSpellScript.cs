using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSpellScript : MonoBehaviour {

	public List<SpellScript> 		spells;

	private Ray				ray;
	private RaycastHit		hit;
	
	void Update () {
		if (Input.GetKeyDown("q") && spells[0].Usage()) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				spells[0].cast(hit.point, transform.rotation);
			}
		}
		if (Input.GetKeyDown("w") && spells[1].Usage()) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				spells[1].cast(hit.point, transform.rotation);
			}
		}
	}
}
