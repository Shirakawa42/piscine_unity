using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float 	bullet_speed;
	public bool 	enemy_bullet;
	public float 	range;
	public bool 	katana = false;
	public bool 	destroyOnCollide = false;
	private Rigidbody rb;
	public bool 		explode = false;
	public GameObject 	explosion;
	public float 		explosion_scale = 1.0f;

	void OnTriggerEnter (Collider other) {
		if (enemy_bullet && other.tag == "Player")
		{
			other.GetComponent<Player>().die();
		}
		else if (!enemy_bullet && other.tag == "Enemy")
		{
			other.transform.parent.GetComponent<EnemyScript>().dead();
			Die();
		}
		else if (other.tag == "AMMO" && katana)
		{
			Destroy(other.transform.parent.gameObject);
		}
		else if (destroyOnCollide && (other.tag == "MAP" || other.tag == "DOOR"))
		{
			Die();
		}
	}

	void Die () {
			if (explode)
			{
				GameObject tmp = Instantiate(explosion, transform.position, transform.rotation);
				tmp.transform.localScale = new Vector3(explosion_scale, explosion_scale, 1.0f);
			}
			Destroy(this.gameObject);
	}

	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * bullet_speed;
	}
	
	void Update () {
		range -= bullet_speed / 100;
		if (range <= 0)
		{
			Die();
		}
	}
}
