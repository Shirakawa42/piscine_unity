using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	private List<GameObject>	enemyList;
	private int					enemyCount;

	void Start () {
		GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
		enemyCount = enemyArray.Length;
	}

	public void updateEnemyCount(){
		enemyCount--;

        Debug.Log(enemyCount);
		if (enemyCount == 0){
			UIManager.manager.DisplayWinOrLoose(true);
		}

	}
}
