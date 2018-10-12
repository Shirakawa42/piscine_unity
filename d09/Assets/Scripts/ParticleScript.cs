using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

	public float	particleLifeTime;

	private void Die () {
		Destroy(gameObject);
	}

	void Start () {
		Invoke("Die", particleLifeTime);
	}
}
