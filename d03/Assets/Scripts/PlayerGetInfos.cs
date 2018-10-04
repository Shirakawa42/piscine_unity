using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGetInfos : MonoBehaviour {

	public gameManager	GM;
	public Text			playerHP;
	public Text			playerEnergie;

	void Start () {
		
	}
	
	void Update () {
		playerHP.text = "Player HP: " + GM.playerHp + "/" + GM.playerMaxHp;
		playerEnergie.text = "Player Energie: " + GM.playerEnergy;
	}
}
