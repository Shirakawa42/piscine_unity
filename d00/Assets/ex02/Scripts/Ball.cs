using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float	speed;
	// Use this for initialization
	void Start () {
		speed = 0.00f;
	}
	
	// Update is called once per frame
	void Update () {
		if (speed != 0.00f)
			transform.Translate(new Vector3(0.01f * speed, 0.0f, 0.0f));
		if (transform.position.x >= 6.72f || transform.position.x <= -6.72f)
			speed = -speed;
		if (speed > 0.00f)
			speed -= 0.25f;
		else if (speed < 0.00f)
			speed += 0.25f;
		if (transform.position.x >= 5.27 && transform.position.x <= 5.66 && ((speed >= 0.0f && speed <= 5.0f) || (speed >= -5.0f && speed < 0.00f)))
		{
			Debug.Log("Ball in the hole !");
			transform.Translate(new Vector3(-10.0f, 0.0f, 0.0f));
			speed = 0.00f;
		}
	}
}
