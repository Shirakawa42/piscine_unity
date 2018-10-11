using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovements : MonoBehaviour {

	public Image 				boost;

	private CharacterController	controller;
	private float 				speed = 6.0f;
	private float 				turnSpeed = 90.0f;

	void Start() {
    	controller = transform.parent.GetComponent<CharacterController>();
	}
 
	void Update() {
		if (Input.GetKey(KeyCode.LeftShift)) {
			boost.fillAmount -= 0.2f * Time.deltaTime;
			if (boost.fillAmount > 0.0f)
				speed = 18.0f;
			else
				speed = 6.0f;
		}
		else if (!Input.GetKey(KeyCode.LeftShift) && boost.fillAmount < 100.0f) {
			boost.fillAmount += 0.05f * Time.deltaTime;
			speed = 6.0f;
		}
		if (Input.GetKey("w"))
			controller.Move(transform.forward * speed * Time.deltaTime - Vector3.up * 0.1f);
		else if (Input.GetKey("s"))
			controller.Move(-transform.forward * speed * Time.deltaTime - Vector3.up * 0.1f);
		if (Input.GetKey("a"))
	    	transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
	    else if (Input.GetKey("d"))
	    	transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
	}
}
