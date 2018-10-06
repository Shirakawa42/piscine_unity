using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWeapon : MonoBehaviour {

	public Weapon 		given_weapon;
	public GameObject 	ground_weapon_prefab;
	public int 			ammo;
	public int 			id;

	void OnTriggerStay (Collider other) {
		if (Input.GetKeyDown("e") && other.transform.tag == "Player") {
			given_weapon.ammo = ammo;
			given_weapon.weapon_id = id;
			given_weapon.equip(
				other.transform.GetChild(other.transform.childCount - 1).GetComponent<SpriteRenderer>(),
				other.transform.GetChild(other.transform.childCount - 1).GetComponent<Weapon>()
			);
			Destroy(this.gameObject);
		}
	}
}
