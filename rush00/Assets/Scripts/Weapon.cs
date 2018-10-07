using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

	public Sprite			equiped_sprite;
	public GameObject[]		ground_weapon_prefab;
	public int 				weapon_id;
	public int 				ammo;
	public bool 			cac;
	public float 			fireRate;
	public GameObject 		bullet_type;
	public AudioClip 		audioclip;
	public AudioClip 		eject;
	private bool 			canShoot;
	public Text 			ammoText;

	public void equip(SpriteRenderer sr, Weapon bs) {
		if (bs.fireRate != -1.0f)
			bs.drop();
		sr.sprite = equiped_sprite;
		bs.ammo= ammo;
		bs.cac = cac;
		bs.fireRate = fireRate;
		bs.bullet_type = bullet_type;
		bs.ground_weapon_prefab = ground_weapon_prefab;
		bs.weapon_id = weapon_id;
		bs.audioclip = audioclip;
		bs.eject = eject;
		if (!cac)
			bs.ammoText.text = "AMMO\n" + ammo;
		else
			bs.ammoText.text = "AMMO\nINFINITE";
		}

	private void fireRateHandler () {
		canShoot = true;
	}

	public void shoot () {
		canShoot = false;
		if (!cac)
		{
			ammo--;
			ammoText.text = "AMMO\n" + ammo;
		}
		GetComponent<AudioSource>().clip = audioclip;
		GetComponent<AudioSource>().Play();
		Instantiate(bullet_type, transform.position, transform.rotation * Quaternion.Euler(-Vector3.forward * 90));
		Invoke("fireRateHandler", fireRate);
	}

	public void drop () {
		GetComponent<AudioSource>().clip = eject;
		GetComponent<AudioSource>().Play();
		GameObject 	cpy = Instantiate(ground_weapon_prefab[weapon_id], transform.parent.transform.position, transform.rotation * Quaternion.Euler(-Vector3.forward * 90));
		cpy.GetComponent<Rigidbody>().AddForce(-transform.up * 300.0f);
		cpy.GetComponent<GroundWeapon>().ammo = ammo;
		fireRate = -1.0f;
		GetComponent<SpriteRenderer>().sprite = null;
		ammoText.text = "NO\nWEAPON";
	}

	void Start () {
		canShoot = true;
	}

	void Update () {
		if (tag == "Player" && Input.GetMouseButton(0) && canShoot)
		{
			if (ammo > 0 || cac== true)
				shoot();
		}
		if (tag == "Player" && Input.GetMouseButtonDown(1) && fireRate != -1)
		{
			drop();
		}
	}
}
