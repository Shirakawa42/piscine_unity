using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MayaScript : MonoBehaviour {

	private Animator		anim;
	private NavMeshAgent	NMA;
	private Ray				ray;
	private RaycastHit		hit;

	void Start () {
		anim = GetComponent<Animator>();
		NMA = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.tag == "Terrain") {
					NMA.SetDestination(hit.point);
				}
				anim.SetTrigger("run");
			}
		}
		if (Vector3.Distance(NMA.destination, transform.position) <= 0.5f) {
			anim.ResetTrigger("run");
		}
	}
}
