using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringScript : MonoBehaviour {

	private gameUI		gUI;
	// Use this for initialization
	void Start () {
		gUI = GameObject.Find("gameUICanvas").GetComponent<gameUI>();
	}
	
	void OnTriggerEnter2D( Collider2D other ) {
		gUI.rings_count++;
		Object.Destroy(this.gameObject);
	}
}
