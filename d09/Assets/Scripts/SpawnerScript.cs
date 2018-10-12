using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	private gameManager	GM;
	public 	GameObject	enemy;
	public GameObject	boss;
	public bool 		active;
	private bool 		spawnCD;
	public int 		HP = 100;

	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<gameManager>();
		spawnCD = true;
	}

	void SetSpawnCD () {
		spawnCD = true;
	}
	
	void Update () {
		if (spawnCD && active) {
			if (Random.Range(0.0f, 100.0f) > 50.0f)
			{
				GameObject cpy = Instantiate(enemy, transform.position, transform.rotation);
				cpy.GetComponent<UnitScript>().HP = HP;
			}
			else
			{
				GameObject cpy = Instantiate(boss, transform.position, transform.rotation);
				cpy.GetComponent<UnitScript>().HP = 8 * HP;
			}
			GM.unitCount++;
			spawnCD = false;
			Invoke("SetSpawnCD", Random.Range(2.0f, 10.0f));
		}
	}
}
