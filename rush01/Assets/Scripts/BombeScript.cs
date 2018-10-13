using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeScript : MonoBehaviour {

	public  SpellScript		spellscript;
	private float			time;
	private List<Collider>	colliders;
	private int 			Damages;

	void OnTriggerStay (Collider other) {
		if (time <= 0.0f && other.tag == "enemy" && !colliders.Contains(other)) {
			colliders.Add(other);
			Debug.Log("Dealing " + Damages + " to " + other.tag);
		}
	}

	void Start () {
		time = 2.0f;
		Damages = spellscript.Damages;
	}

	void Update () {
		time -= Time.deltaTime;
		if (time < -0.5f) {
			Destroy(gameObject);
		}
	}

}
