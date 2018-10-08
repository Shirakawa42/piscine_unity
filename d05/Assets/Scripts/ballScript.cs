using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	
	public bool 		isMoving = false;
	private Rigidbody 	rb;

	public void 	shoot(float power, GameObject arrow) {
		isMoving = true;
		rb.AddForce((arrow.transform.position - transform.position) * (power * 2000.0f));
	}

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (rb.velocity == Vector3.zero)
			isMoving = false;
		else
			isMoving = true;
	}
}
