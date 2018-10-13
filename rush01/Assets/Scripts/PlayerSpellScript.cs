using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerSpellScript : MonoBehaviour {

	public List<SpellScript> 		spells;
	public Canvas					talent_tree;
	public int 						talent_points;
	public Text 					talent_points_text;
	public int 						used_talent_points = 0;
	public GameObject 				high_level;

	private Ray				ray;
	private RaycastHit		hit;
	private bool			talent_tree_active = false;
	
	public void useTalentPoint() {
		talent_points--;
		used_talent_points++;
		talent_points_text.text = "Points: " + talent_points;
		if (used_talent_points > 5) {
			high_level.SetActive(true);
		}
	}

	public void grantTalentPoint() {
		talent_points++;
		talent_points_text.text = "Points: " + talent_points;
	}

	void Start () {
		talent_points_text.text = "Points: " + talent_points;
	}

	void Update () {
		if (spells[0] != null && Input.GetKeyDown("1") && spells[0].Usage()) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				spells[0].cast(hit.point, transform.rotation);
			}
		}
		if (spells[1] != null && Input.GetKeyDown("2") && spells[1].Usage()) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				spells[1].cast(hit.point, transform.rotation);
			}
		}
		if (spells[2] != null && Input.GetKeyDown("3") && spells[2].Usage()) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				spells[2].cast(hit.point, transform.rotation);
			}
		}
		if (spells[3] != null && Input.GetKeyDown("4") && spells[3].Usage()) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				spells[3].cast(hit.point, transform.rotation);
			}
		}
		if (Input.GetKeyDown("n")) {
			talent_tree.gameObject.SetActive(!talent_tree_active);
			talent_tree_active = !talent_tree_active;
		}
	}
}
