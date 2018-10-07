using UnityEngine;

public class MenuButtonsManager : MonoBehaviour {

    [SerializeField] private MenuButtons[] menu_buttons;

    private int selected_on_menu = 0;

	// Use this for initialization
	void Start () {
        SelectFirstButton();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            SelectNextButton();
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            SelectPrevButton();
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            ValidSelection();
	}

    public void SelectFirstButton() {
        selected_on_menu = GetNextValidButton(-1);
        Debug.Log(selected_on_menu);
        menu_buttons[selected_on_menu].SetIsSelected(true);
    }

    // PRIVATE METHODS

    // BUTTON SELECTION

    private void SelectNextButton() {
        menu_buttons[selected_on_menu].SetIsSelected(false);
        selected_on_menu = GetNextValidButton(selected_on_menu);
        menu_buttons[selected_on_menu].SetIsSelected(true);
    }

    private void SelectPrevButton() {
        menu_buttons[selected_on_menu].SetIsSelected(false);
        selected_on_menu = GetPrevValidButton(selected_on_menu);
        menu_buttons[selected_on_menu].SetIsSelected(true);
    }

    private int GetNextValidButton(int current_button) {
        current_button++;

        while (current_button < menu_buttons.Length
               && !menu_buttons[current_button].isActiveAndEnabled)
            current_button++;

        if (current_button >= menu_buttons.Length)
            current_button = GetNextValidButton(-1);

        return current_button;
    }

    private int GetPrevValidButton(int current_button) {
        current_button--;

        while (current_button >= 0
               && !menu_buttons[current_button].isActiveAndEnabled)
            current_button--;

        if (current_button < 0)
            current_button = GetPrevValidButton(menu_buttons.Length);

        return current_button;
    }

    private void ValidSelection() {
        menu_buttons[selected_on_menu].ValidSelection();
    }
}
