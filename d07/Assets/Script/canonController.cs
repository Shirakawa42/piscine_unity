using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canonController : MonoBehaviour {
	
	public GameObject 	missileParticle;
	public GameObject 	bulletParticle;
	public AudioSource	bulletImpact;
	public AudioSource	missileImpact;
	public AudioSource	missileNoImpact;
	public TextMesh 	AmmoText;
	public TextMesh 	HPText;
	public Image		cursor;

	private float 		speed = 180.0f;
	private float 		missileCD = 2.0f;
	private float 		bulletCD = 0.2f;
	private int 		missileAmmo = 10;
	private bool 		missileCanShoot = true;
	private bool 		bulletCanShoot = true;
	private tankScript	TS;

	private void 	missileSetCanShoot() {
		missileCanShoot = true;
	}

	private void 	bulletSetCanShoot() {
		bulletCanShoot = true;
	}

	private void	shootMissile() {
		RaycastHit 	hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 100)) {
			Instantiate(missileParticle, hit.point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
			missileImpact.Play();
			if (hit.collider.tag == "Enemy")
				hit.collider.transform.parent.GetComponent<tankScript>().takeDamages(20);
		}
		else
			missileNoImpact.Play();
		missileCanShoot = false;
		missileAmmo--;
		AmmoText.text = "AMMO: " + missileAmmo + "/10";
		Invoke("missileSetCanShoot", missileCD);
	}

	private void 	shootBullet() {
		RaycastHit 	hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 100)) {
			Instantiate(bulletParticle, hit.point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
			if (hit.collider.tag == "Enemy")
				hit.collider.transform.parent.GetComponent<tankScript>().takeDamages(3);
		}
		bulletImpact.Play();
		bulletCanShoot = false;
		Invoke("bulletSetCanShoot", bulletCD);
	}

	void Start () {
		TS = transform.parent.GetComponent<tankScript>();
	}

	void Update () {
		RaycastHit 	hit;

		if(Input.GetAxis("Mouse X") < 0)
			transform.Rotate(Vector3.up * -speed * Time.deltaTime);
		if(Input.GetAxis("Mouse X") > 0)
			transform.Rotate(Vector3.up * speed * Time.deltaTime);
		if (Input.GetMouseButton(1) && missileAmmo > 0 && missileCanShoot)
			shootMissile();
		if (Input.GetMouseButton(0) && bulletCanShoot)
			shootBullet();
		if (Physics.Raycast(transform.position, transform.forward, out hit, 100)) {
			if (hit.collider.tag == "Enemy")
				cursor.color = Color.red;
			else
				cursor.color = Color.black;
		}
		HPText.text = "HP: " + TS.HP + "/" + TS.maxHP;
	}
}
