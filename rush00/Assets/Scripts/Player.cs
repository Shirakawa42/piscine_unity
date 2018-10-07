using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public void die () {
        SoundManager.manager.PlayerLooseSound();
		UIManager.manager.DisplayWinOrLoose(false);
        Destroy(gameObject);
	}

    public void win () {
        SoundManager.manager.PlayerWinSound();
        UIManager.manager.DisplayWinOrLoose(true);
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
