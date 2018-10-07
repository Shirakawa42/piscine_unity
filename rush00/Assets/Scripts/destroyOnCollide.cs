using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollide : MonoBehaviour {

	void 	OnTriggerEnter(Collider other)
	{
		Debug.Log("test");
		//Destroy(transform.parent.gameObject);
	}
}
