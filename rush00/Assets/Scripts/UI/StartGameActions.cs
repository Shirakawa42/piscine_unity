using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameActions : MonoBehaviour {

    public string first_level = "";

    public void StartGame() {
        //Debug.Log("start game");
        if (first_level != "")
            SceneManager.LoadScene(first_level);
    }

    public void ExitGame() {
        //Debug.Log("exit game");
        Application.Quit();
    }
}
