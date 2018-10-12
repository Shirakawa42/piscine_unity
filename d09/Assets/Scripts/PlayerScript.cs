using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject	weapon1;
	public GameObject	weapon2;
	public int			life;

	private int			selectedWeapon = 1;
	private GameObject	currentWeapon;

	void Start () {
		currentWeapon = Instantiate(weapon1);
		currentWeapon.transform.parent = transform;
		currentWeapon.transform.localPosition = weapon1.transform.localPosition;
		currentWeapon.transform.localRotation = weapon1.transform.localRotation;
	}
	
	void Update () {
		if (Input.GetKeyDown("1") && selectedWeapon != 1) {
			Destroy(currentWeapon);
			currentWeapon = Instantiate(weapon1);
			currentWeapon.transform.parent = transform;
			currentWeapon.transform.localPosition = weapon1.transform.localPosition;
			currentWeapon.transform.localRotation = weapon1.transform.localRotation;
			selectedWeapon = 1;
		}
		else if (Input.GetKeyDown("2") && selectedWeapon != 2) {
			Destroy(currentWeapon);
			currentWeapon = Instantiate(weapon2);
			currentWeapon.transform.parent = transform;
			currentWeapon.transform.localPosition = weapon2.transform.localPosition;
			currentWeapon.transform.localRotation = weapon2.transform.localRotation;
			selectedWeapon = 2;
		}
	}
}
