using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour {

	public List<unit_movement_01>	units;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
			clear();
	}

	public void clear()
	{
		foreach (unit_movement_01 unit in units)
			unit.selected = false;
		units.Clear();
	}
}
