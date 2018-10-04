using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGetInfos : MonoBehaviour {

	public towerScript	tower;
	public Text			Cost;
	public Text			Range;
	public Text			Damages;
	public Text			CD;

	void Start () {
		Cost.text = "Energie: " + tower.energy;
		Range.text = "Portee: " + tower.range;
		Damages.text = "Degats: " + tower.damage;
		CD.text = "Recharge: " + tower.fireRate;
	}
	
	void Update () {
		
	}
}
