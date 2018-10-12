using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	public int 		unitCount;
	public SpawnerScript	spawner1;
	public SpawnerScript	spawner2;
	public SpawnerScript	spawner3;
	public SpawnerScript	spawner4;
	public Text 			wave;
	public Text 			remainingTime;
	public Text 			message;
	public bool 			end;

	private bool inWave = true;
	public int currentWave;
	private float	currentTime;

	void SetActive (bool active) {
			spawner1.active = active;
			spawner2.active = active;
			spawner3.active = active;
			spawner4.active = active;
	}

	void Start () {
		unitCount = 0;
		currentWave = 1;
		currentTime = 30.0f;
		end = false;
		messagea("new wave started");
	}

	void reactive () {
		SetActive(true);
		currentTime = 30.0f;
		inWave = true;
		messagea("new wave started");
	}

	void removeMessage () {
		message.text = "";
	}

	void messagea (string messageq) {
		message.text = messageq;
		Invoke("removeMessage", 3.0f);
	}
	
	void Update () {
		if (!end) {
			if (unitCount >= 20)
				SetActive(false);
			else if (inWave) {
				SetActive(true);
			}
			currentTime -= Time.deltaTime;
			if (currentTime <= 0) {
				SetActive(false);
				currentTime = 10.0f;
				currentWave++;
				spawner1.HP += 30;
				spawner2.HP += 30;
				spawner3.HP += 30;
				spawner4.HP += 30;
				inWave = false;
				messagea("Pause started");
				wave.text = "Wave " + currentWave;
				Invoke("reactive", 10.0f);
			}
			remainingTime.text = "Remaining: " + currentTime;
		}
	}
}
