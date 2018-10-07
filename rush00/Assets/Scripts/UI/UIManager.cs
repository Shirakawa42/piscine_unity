using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager manager;

    [SerializeField]
    private WinLooseUI winOrLooseUI;

	void Start () {
        if (manager == null) {
			manager = this;
        }
	}

    public void DisplayWinOrLoose(bool win) {
        GameObject.Find("Player").GetComponent<playerMovement>().canMove = false;
        winOrLooseUI.Display(win);
    }
}
