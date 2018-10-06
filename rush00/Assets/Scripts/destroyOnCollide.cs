using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollide : MonoBehaviour {

	void 	OnCollisionEnter(Collision other)
	{
		Destroy(transform.parent.gameObject);
	}
}
