using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public GameObject	target;

	void OnTriggerEnter2D (Collider2D other)
	{
		other.transform.position = target.transform.position;
	}
}
