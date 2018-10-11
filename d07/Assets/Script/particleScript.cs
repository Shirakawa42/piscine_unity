using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour {

	
	private void 	Die() {
		Destroy(gameObject);
	}

	void Start () {
		Invoke("Die", 1.0f);
	}
}
