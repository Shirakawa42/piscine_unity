using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	public Ball		ball;
	private float	power;
	private int		score;
	// Use this for initialization
	void Start () {
		power = 0.00f;
		score = -15;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.speed == 0.00f)
		{
			if (Input.GetKey("space"))
			{
				power += 0.50f;
			}
			else
			{
				ball.speed = Mathf.Clamp(power, 0.00f, 30.00f);
				if (power != 0.00f)
				{
					score += 5;
					Debug.Log("Score: " + score);
				}
				power = 0.00f;
			}
		}
	}
}
