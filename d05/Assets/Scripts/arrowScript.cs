using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {

	public GameObject 	ball;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKey("e"))
			transform.RotateAround(ball.transform.position, Vector3.up, 5.0f);
		else if (Input.GetKey("a"))
			transform.RotateAround(ball.transform.position, -Vector3.up, 5.0f);

	}
}
