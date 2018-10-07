using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLooseUI : MonoBehaviour {

    [SerializeField]
    private GameObject screen;
    [SerializeField]
    private GameObject restart_button;
    [SerializeField]
    private GameObject next_level_button;
    [SerializeField]
    private GameObject back_to_menu_button;


    [SerializeField]
    private GameObject loose_message;
    [SerializeField]
    private GameObject win_message;

    [SerializeField]
    private MenuButtonsManager menu_buttons_manager;


	// Use this for initialization
	void Start () {
        back_to_menu_button.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {		
	}

    public void Display(bool win) {
        screen.SetActive(true);

        restart_button.SetActive(!win);
        next_level_button.SetActive(win);
        loose_message.SetActive(!win);
        win_message.SetActive(win);

        menu_buttons_manager.SelectFirstButton();
    }
}
