using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeController : MonoBehaviour {

	public cameraController	camera;
	public GameObject[] 	holes;
	private int 			actual;

	public bool 	isGood (int nb) {
		if (nb == actual) 
		{
			actual++;
			camera.actual_hole = holes[actual - 1];
			return true;
		}
		return false;
	}

	void Start () {
		actual = 1;
		camera.actual_hole = holes[0];
	}
}
