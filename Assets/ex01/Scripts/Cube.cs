using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	private float		speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range(-0.05f, -0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x == -5.2f || this.transform.position.x == 0.0f || this.transform.position.x == 5.2f)
		{
			transform.Translate(new Vector3(0, speed, 0));
		}
	}
}