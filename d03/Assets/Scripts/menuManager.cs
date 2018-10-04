using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

	public GameObject	canvas;
	public GameObject	confirmCanvas;
	public gameManager	GM;
	private bool		active;
	// Use this for initialization
	void Start () {
		active = false;
		canvas.SetActive(false);
		confirmCanvas.SetActive(false);
	}

	public void Restart()
	{
		active = false;
		canvas.SetActive(false);
		confirmCanvas.SetActive(false);
		GM.pause(false);
	}

	public void No()
	{
		active = true;
		canvas.SetActive(true);
		confirmCanvas.SetActive(false);
	}

	public void Quit()
	{
		active = true;
		canvas.SetActive(false);
		confirmCanvas.SetActive(true);
	}

	public void ConfirmQuit()
	{
		SceneManager.LoadScene("ex00", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
		{
			active = !active;
			canvas.SetActive(active);
			confirmCanvas.SetActive(false);
			GM.pause(active);
		}
	}
}
