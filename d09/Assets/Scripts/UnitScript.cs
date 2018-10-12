using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour {

	private int 	HP = 100;

	public void 	takeDamages(int damages) {
		HP -= damages;
		if (HP <= 0)
			Destroy(gameObject);
	}
}
