using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject player;

	void Update () {
		Vector3 	pos = player.transform.position;
		pos.y += 15;
		transform.position = pos;
	}
}
