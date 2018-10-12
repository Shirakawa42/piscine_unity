using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCript : MonoBehaviour {

	private NavMeshAgent	agent;
	private GameObject		player;

	public void OnHit () {
		if (agent)
			agent.SetDestination(player.transform.position);
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player" && agent)
			agent.SetDestination(other.transform.position);
	}

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(new Vector3(31, -69, -16));
		player = GameObject.Find("Player");
	}
	
	void Update () {
		if (player)
			agent.SetDestination(player.transform.position);
	}
}
