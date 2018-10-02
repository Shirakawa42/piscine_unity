using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore_collision : MonoBehaviour {

	public string	target_name;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (target_name != collision.collider.name)
		{
			Physics2D.IgnoreCollision(collision.otherCollider, collision.collider);
		}
	}
}
