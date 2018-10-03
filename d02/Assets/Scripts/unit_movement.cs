using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_movement : MonoBehaviour {

	private Animator	animator;
	private float		angle;
	private Ray			goTo;
	private string		current;
	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		current = "Idle";
		goTo.origin = transform.position;
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			goTo = Camera.main.ScreenPointToRay(Input.mousePosition);
			goTo.origin = new Vector3(goTo.origin.x, goTo.origin.y, 0.0f);
			angle = Vector3.Angle(goTo.origin - transform.position, new Vector3(0.0f, 1.0f, 0.0f));
			if (goTo.origin.x < transform.position.x)
				angle = -angle;
			GetComponent<AudioSource>().Play();
		}
		if (goTo.origin != transform.position)
		{
			animator.ResetTrigger(current);
			if (angle <= 22.5f && angle >= -22.5f && current != "North")
				current = "North";
			else if (angle > 22.5f && angle <= 67.5f && current != "NorthEast")
				current = "NorthEast";
			else if (angle > 67.5f && angle <= 112.5f && current != "East")
				current = "East";
			else if (angle > 112.5f && angle <= 157.5f && current != "SouthEast")
				current = "SouthEast";
			else if ((angle > 157.5f || angle <= -157.5f) && current != "South")
				current = "South";
			else if (angle > -157.5f && angle <= -112.5f && current != "SouthWest")
			{
				current = "SouthWest";
				sprite.flipX = true;
			}
			else if (angle > -112.5f && angle <= -67.5f && current != "West")
			{
				current = "West";
				sprite.flipX = true;
			}
			else if (angle > -67.5f && angle < -22.5f && current != "NorthWest")
			{
				current = "NorthWest";
				sprite.flipX = true;
			}
			animator.SetTrigger(current);
		}
		else if (current != "Idle")
		{
			animator.ResetTrigger(current);
			current = "Idle";
			animator.SetTrigger(current);
		}
		if (sprite.flipX == true && current != "NorthWest" && current != "West" && current != "SouthWest")
			sprite.flipX = false;
		transform.position = Vector3.MoveTowards(transform.position, goTo.origin , 3 * Time.deltaTime);
	}
}
