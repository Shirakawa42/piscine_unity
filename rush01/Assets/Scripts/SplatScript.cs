using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatScript : MonoBehaviour {

	public SpellScript		spellscript;
	private RaycastHit 		hit;
	private Ray 			ray;

	void Start () {
		
	}
	
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			hit.point += new Vector3(0, transform.position.y, 0);
			transform.position = hit.point;
		}
		if (Input.GetKeyDown(0)) {
			
		}
	}
}
