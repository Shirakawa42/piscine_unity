using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWeapon : MonoBehaviour {

	public Weapon 		given_weapon;
	public GameObject 	ground_weapon_prefab;
	public int 			ammo;
	public int 			id;
	private Rigidbody 	rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy" && id != 0 && (Mathf.Abs(rb.velocity.x) >= 3 || Mathf.Abs(rb.velocity.y) >= 3 || Mathf.Abs(rb.velocity.z) >= 3))
		{
			other.transform.parent.GetComponent<EnemyScript>().stunt();
		}
		else if (other.tag == "Enemy" && id == 0 && (Mathf.Abs(rb.velocity.x) >= 3 || Mathf.Abs(rb.velocity.y) >= 3 || Mathf.Abs(rb.velocity.z) >= 3))
		{
			other.transform.parent.GetComponent<EnemyScript>().dead();
		}
	}

	void OnTriggerStay (Collider other) {
		if (Input.GetKeyDown("e") && other.transform.tag == "Player") {
            SoundManager.manager.PlayerGetWeaponSound();
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
