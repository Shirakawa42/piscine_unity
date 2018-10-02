using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float	speed;
	public bool 	stop;
	public int		score;
	public Pipe pipe1;
	public Pipe pipe2;
	// Use this for initialization
	void Start () {
		speed = 0.00f;
		stop = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!stop)
		{
			transform.Translate(new Vector3(0.0f, speed, 0.0f));
			speed -= 0.005f;
			score += 1;
			if (Input.GetKeyDown("space"))
				speed = 0.12f;
			if (transform.position.y <= -3.0f)
			{
				Debug.Log("Score: " + score);
				Debug.Log("Time: " + Time.realtimeSinceStartup);
				pipe1.stop = true;
				pipe2.stop = true;
				stop = true;
			}
		}
		else
		{
			pipe1.stop = true;
			pipe2.stop = true;
		}
	}
}
