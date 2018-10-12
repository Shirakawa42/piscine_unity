using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

	private NavMeshAgent	agent;

	public void OnHit () {
		if (agent)
			agent.SetDestination(GameObject.Find("Player").transform.position);
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player")
			agent.SetDestination(other.transform.position);
	}

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(new Vector3(31, -69, -16));
	}
	
	void Update () {
		
	}
}
