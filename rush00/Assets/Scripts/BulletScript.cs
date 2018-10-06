using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float 	bullet_speed;
	public bool 	enemy_bullet;
	public float 	range;
	private Rigidbody rb;

	void OnTriggerEnter (Collider other) {
		if (enemy_bullet && other.tag == "Player")
		{
			other.GetComponent<Player>().die();
		}
		else if (!enemy_bullet && other.tag == "Enemy")
		{
			// kill enemy
		}
	}

	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * bullet_speed;
	}
	
	void Update () {
		range -= bullet_speed / 100;
		if (range <= 0)
			Destroy(this.gameObject);
	}
}
