using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUI : MonoBehaviour {

	public Text		rings;
	public Text		score;
	public Text		time;
	public int		rings_count;
	public int		score_count;
	private int		currentSec;
	private int		currentMs;
	private int		ringChange;
	public int		realScore;

	void updateTime () {
		currentMs++;
		if (currentMs >= 100)
		{
			currentMs -= 100;
			currentSec++;
			updateScore();
		}
		time.text = "Time: " + currentSec + ":" + currentMs;
	}

	void updateScore() {
		int		tmp;

		tmp = score_count - currentSec * 20;
		if (tmp < 0)
			tmp = 0;
		realScore =  tmp + (rings_count * 100);
		score.text = "Score: " + realScore;
	}

	void Start () {
		ringChange = 0;
		rings_count = 0;
		currentSec = 0;
		currentMs = 0;
		rings.text = "Anneaux: " + rings_count;
		InvokeRepeating("updateTime", 0, 0.01f);
		score.text = "Score: " + (score_count - (currentSec * 20) + (rings_count * 100));
	}
	
	void Update () {
		if (ringChange != rings_count)
		{
			rings.text = "Anneaux: " + rings_count;
			ringChange = rings_count;
			updateScore();
			GetComponent<AudioSource>().Play();
		}
	}
}
