using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paperTrigger : MonoBehaviour {

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player" && Input.GetKeyDown("e"))
			SceneManager.LoadScene("ex00");
	}
}
