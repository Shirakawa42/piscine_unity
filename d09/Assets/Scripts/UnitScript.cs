using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {

	public int 	HP = 100;

	public void 	takeDamages(int damages) {
		HP -= damages;
		if (tag == "enemy")
			GetComponent<EnemyScript>().OnHit();
		else
			GetComponent<BossCript>().OnHit();
		if (HP <= 0) {
			GameObject.Find("GameManager").GetComponent<gameManager>().unitCount--;
			Destroy(gameObject);
		}
	}
}
