using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tankScript : MonoBehaviour {

	public int	HP = 150;
	public int maxHP = 150;

	public void 	takeDamages(int damages) {
		HP -= damages;
		if (HP <= 0) {
			if (tag == "Player")
				SceneManager.LoadScene("game");
			Destroy(gameObject);
		}
	}
}
