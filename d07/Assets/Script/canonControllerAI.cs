using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonControllerAI : MonoBehaviour {

	public GameObject 	missileParticle;
	public GameObject 	bulletParticle;
	public AudioSource	bulletImpact;
	public AudioSource	missileImpact;
	public AudioSource	missileNoImpact;
	public GameManager	GM;
	public GameObject	currentTarget;

	private float 		speed = 1.0f;
	private float 		missileCD = 2.0f;
	private float 		bulletCD = 0.2f;
	private int 		missileAmmo = 10;
	private bool 		missileCanShoot = true;
	private bool 		bulletCanShoot = true;
	private Vector3		targetPoint;
	private Quaternion	targetRotation;

	private void 	missileSetCanShoot() {
		missileCanShoot = true;
	}

	private void 	bulletSetCanShoot() {
		bulletCanShoot = true;
	}

	private void	shootMissile() {
		Vector3		random = new Vector3(transform.forward.x * Random.Range(0.5f, 1.5f), transform.forward.y * Random.Range(0.5f, 1.5f), transform.forward.z * Random.Range(0.5f, 1.5f));
		RaycastHit 	hit;

		if (Physics.Raycast(transform.position, random, out hit, 100)) {
			Instantiate(missileParticle, hit.point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
			missileImpact.Play();
			if (hit.collider.tag == "Enemy" || hit.collider.tag == "Player")
				hit.collider.transform.parent.GetComponent<tankScript>().takeDamages(20);
		}
		else
			missileNoImpact.Play();
		missileCanShoot = false;
		missileAmmo--;
		Invoke("missileSetCanShoot", missileCD + Random.Range(0.0f, 2.0f));
	}

	private void 	shootBullet() {
		Vector3		random = new Vector3(transform.forward.x * Random.Range(0.5f, 1.5f), transform.forward.y * Random.Range(0.5f, 1.5f), transform.forward.z * Random.Range(0.5f, 1.5f));
		RaycastHit 	hit;

		if (Physics.Raycast(transform.position, random, out hit, 100)) {
			Instantiate(bulletParticle, hit.point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
			if (hit.collider.tag == "Enemy" || hit.collider.tag == "Player")
				hit.collider.transform.parent.GetComponent<tankScript>().takeDamages(3);
		}
		bulletImpact.Play();
		bulletCanShoot = false;
		Invoke("bulletSetCanShoot", bulletCD + Random.Range(0.0f, 0.5f));
	}

	void Start () {
		currentTarget = GM.tanks[0];
	}

	void Update () {
		if (!currentTarget)
			currentTarget = GM.tanks[0];
		foreach	(GameObject tank in GM.tanks) {
			if (tank && Vector3.Distance(transform.position, tank.transform.position) < Vector3.Distance(transform.position, currentTarget.transform.position) && tank != gameObject)
				currentTarget = tank;
		}
		targetPoint = new Vector3(currentTarget.transform.position.x, transform.position.y, currentTarget.transform.position.z) - transform.position;
        targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
		if (missileAmmo > 0 && missileCanShoot && currentTarget.transform.position.y > transform.position.y - 2f && currentTarget.transform.position.y < transform.position.y + 2f)
			shootMissile();
		if (bulletCanShoot && currentTarget.transform.position.y > transform.position.y - 2f && currentTarget.transform.position.y < transform.position.y + 2f)
			shootBullet();
	}
}
