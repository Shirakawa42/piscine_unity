using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour {

	public void		goToEx01()
	{
		SceneManager.LoadScene("ex01", LoadSceneMode.Single);
	}
}
