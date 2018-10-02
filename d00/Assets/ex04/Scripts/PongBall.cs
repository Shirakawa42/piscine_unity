using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

	private Vector3		direction;
	public Player		playerLeft;
	public Player		playerRight;
	// Use this for initialization
	void Start () {
		direction = new Vector3(0.04f, 0.04f, 0.00f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction);
		if (transform.position.y >= 4.26f || transform.position.y <= -4.26f)
			direction.y = -direction.y;
		if (transform.position.x >= 12.0f)
		{
			transform.Translate(new Vector3(-12.0f, 0.0f, 0.0f));
			direction.x = -direction.x;
			playerLeft.score += 1;
			Debug.Log("Player 1: " + playerLeft.score + " | Player 2: " + playerRight.score);
		}
		else if (transform.position.x <= -12.0f)
		{
			transform.Translate(new Vector3(12.0f, 0.0f, 0.0f));
			direction.x = -direction.x;
			playerRight.score += 1;
			Debug.Log("Player 1: " + playerLeft.score + " | Player 2: " + playerRight.score);
		}
		if (transform.position.x <= -9.8f && transform.position.x >= -10.0f)
		{
			if (transform.position.y <= playerLeft.transform.position.y + 0.8f && transform.position.y >= playerLeft.transform.position.y - 0.8f && direction.x < 0.0f)
			{
				direction.x = -direction.x;
			}
		}
		if (transform.position.x >= 9.8f && transform.position.x <= 10.0f)
		{
			if (transform.position.y <= playerRight.transform.position.y + 0.8f && transform.position.y >= playerRight.transform.position.y - 0.8f && direction.x > 0.0f)
			{
				direction.x = -direction.x;
			}
		}
	}
}
