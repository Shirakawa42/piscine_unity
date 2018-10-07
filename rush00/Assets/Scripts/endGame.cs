using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player"){
			UIManager.manager.DisplayWinOrLoose(true);
		}
	}

}
