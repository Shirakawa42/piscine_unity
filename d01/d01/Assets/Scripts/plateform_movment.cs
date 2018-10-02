using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateform_movment : MonoBehaviour {

	public bool		right;
	public float	speed;
	public bool		vertical;
	public float	distance;
	private float	current_distance;
	// Use this for initialization
	void Start () {
		current_distance = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!vertical)
		{
			if (right)
				transform.Translate(new Vector3(speed, 0.0f, 0.0f));
			else
				transform.Translate(new Vector3(-speed, 0.0f, 0.0f));
		}
		else
		{
			if (right)
				transform.Translate(new Vector3(0.0f, speed, 0.0f));
			else
				transform.Translate(new Vector3(0.0f, -speed, 0.0f));
		}
		current_distance += speed;
		if (current_distance >= distance)
		{
			current_distance = 0.0f;
			right = !right;
		}
	}
}
