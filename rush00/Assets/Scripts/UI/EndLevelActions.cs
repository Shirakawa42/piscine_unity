using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelActions : MonoBehaviour {

    public string next_level;
    public string menu_name;

    public void NextLevel() {
        //Debug.Log("next level");
        if (next_level != "")
            SceneManager.LoadScene(next_level);
    }

    public void BackToMenu() {
        //Debug.Log("back to menu " + menu_name);
        SceneManager.LoadScene(menu_name);
    }

    public void Restart() {
        //Debug.Log("restart level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
