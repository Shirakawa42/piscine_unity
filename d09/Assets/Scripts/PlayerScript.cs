using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public GameObject	weapon1;
	public GameObject	weapon2;
	public int			life;
	public int 			maxHP;
	public Image		lifeBar;

	public GameObject	panel;
	public Text			text;

	private int			selectedWeapon = 1;
	private GameObject	currentWeapon;

	public void 	takeDamages(int damages) {
		life -= damages;
		lifeBar.fillAmount = (float)life / (float)maxHP;
		if (life <= 0) {
			gameManager gm = GameObject.Find("GameManager").GetComponent<gameManager>();
			text.text = "Wave: " + gm.currentWave;
			gm.end = true;
			panel.SetActive(true);
		}
	}

	void Start () {
		currentWeapon = Instantiate(weapon1);
		currentWeapon.transform.parent = transform;
		currentWeapon.transform.localPosition = weapon1.transform.localPosition;
		currentWeapon.transform.localRotation = weapon1.transform.localRotation;
		panel.SetActive(false);
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
