using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovements : MonoBehaviour {

	public canonControllerAI	canon;
	private UnityEngine.AI.NavMeshAgent		agent;
	private float 				speed = 6.0f;
	private float 				turnSpeed = 90.0f;

	void Start() {
    	agent = transform.parent.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
 
	void Update() {
		if (canon.currentTarget)
			agent.destination = canon.currentTarget.transform.position - transform.forward * 6.0f;
	}
}
