using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int		score;
	public string	upKey;
	public string	downKey;
	private bool	hold;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(upKey) && transform.position.y <= 3.75f)
		{
			transform.Translate(new Vector3(0.0f, 0.04f, 0.0f));
		}
		if (Input.GetKey(downKey) && transform.position.y >= -3.75f)
		{
			transform.Translate(new Vector3(0.0f, -0.04f, 0.0f));
		}
	}
}
