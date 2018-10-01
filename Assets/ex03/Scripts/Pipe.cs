using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	private float		speed;
	public GameObject	bird;
	public float		y_top;
	public float		y_bot;
	public bool			stop;
	public Bird			birdScript;
	// Use this for initialization
	void Start () {
		speed = 0.02f;
		stop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!stop)
		{
			speed += 0.0003f;
			transform.Translate(new Vector3(-speed, 0.0f, 0.0f));
			if (transform.position.x <= -18.5f)
				transform.Translate(new Vector3(40.0f, 0.0f, 0.0f));
			if (transform.position.x >= -8.20 && transform.position.x <= -7.50)
			{
				if (bird.transform.position.y >= y_top || bird.transform.position.y <= y_bot)
				{
					Debug.Log("Score: " + birdScript.score);
					Debug.Log("Time: " + Time.realtimeSinceStartup);
					birdScript.stop = true;
				}
			}
		}
	}
}
