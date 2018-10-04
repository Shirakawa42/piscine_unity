using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedScript : MonoBehaviour {

	public float		speed;
	public gameManager	GM;

	// Use this for initialization
	void OnMouseDown () {
		if (Input.GetMouseButtonDown(0))
			GM.changeSpeed(speed);
	}
}
