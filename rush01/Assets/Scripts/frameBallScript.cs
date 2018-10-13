using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameBallScript : MonoBehaviour {

	private  SpellScript		spellscript;
	private float			time;
	private int 			Damages;
	private RaycastHit 		hit;
	private Ray 			ray;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "enemy") {
			Debug.Log("Dealing " + Damages + " to " + other.tag);
		}
	}

	void Die () {
		Destroy(gameObject);
	}

	void Start () {
		spellscript = GetComponent<IAmASpellScript>().spellscript;
		Damages = spellscript.Damages;
		transform.position = GameObject.Find("Player").transform.position;
		Invoke("Die", 6.0f);
	}

	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			hit.point += new Vector3(0, transform.position.y, 0);
			transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 5.0f); 
		}
	}
}
