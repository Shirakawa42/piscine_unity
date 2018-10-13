using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementScript : MonoBehaviour {

	private NavMeshAgent	NMA;
	private Ray				ray;
	private RaycastHit		hit;

	void Start () {
		NMA = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.tag == "Terrain") {
					NMA.SetDestination(hit.point);
				}
			}
		}
	}
}
