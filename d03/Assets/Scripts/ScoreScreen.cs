using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour {

	public GameObject	canvas;
	public GameObject	nextButton;
	public GameObject	restartButton;
	public Text			score;
	public Text			rank;
	public gameManager	GM;
	[HideInInspector]public bool		panel;

	public void nextLevel() {
		SceneManager.LoadScene("ex03", LoadSceneMode.Single);
	}

	public void restart() {
		SceneManager.LoadScene("ex01", LoadSceneMode.Single);
	}

	// Use this for initialization
	void Start () {
		panel = false;
		canvas.SetActive(false);
	}
	
	public string	rankDefine(int s)
	{
		if (s < 7000)
			return "F";
		else if (s < 10000)
			return "E";
		else if (s < 15000)
			return "D";
		else if (s < 20000)
			return "C";
		else if (s < 24000)
			return "B";
		else if (s < 27000)
			return "A";
		else if (s < 30000)
			return "S";
		else if (s < 33000)
			return "SS";
		else if (s < 35000)
			return "SSS";
		else if (s < 38000)
			return "SSS+";
		else if (s < 40000)
			return "X";
		else if (s < 42000)
			return "XX";
		else if (s < 43000)
			return "XXX";
		else if (s < 44000)
			return "XXX+";
		else
			return "XXXX++ Divine";
	}

	private bool checkLastEnemy() {
		if (GM.lastWave == true) {
			GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawner");
			foreach (GameObject spawner in spawners) {
				if (spawner.GetComponent<ennemySpawner>().isEmpty == false || spawner.transform.childCount > 1) {
					return false;
				}
			}
			return true;
		}
		return false;
	}
	// Update is called once per frame
	void Update () {
		if (GM.playerHp <= 0 && !panel)
		{
			panel = true;
			canvas.SetActive(true);
			nextButton.SetActive(false);
			restartButton.SetActive(true);
			score.text = "" + GM.score;
			rank.text = rankDefine(GM.score + GM.playerEnergy + (GM.playerHp * 15));
		}
		if (checkLastEnemy() && !panel)
		{
			panel = true;
			canvas.SetActive(true);
			nextButton.SetActive(true);
			restartButton.SetActive(false);
			score.text = "" + GM.score;
			rank.text = rankDefine(GM.score + GM.playerEnergy + (GM.playerHp * 15));
		}
	}
}
