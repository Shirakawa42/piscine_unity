using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {


	public GameObject	baloon;
	private float		souffle = 100.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && souffle > 30.0F)
		{
			baloon.transform.localScale += new Vector3(0.05F, 0.05F, 0.05F);
			souffle -= 6.5F;
		}
		if (baloon.transform.localScale.x > 0.5)
		{
			baloon.transform.localScale -= new Vector3(0.001F, 0.001F, 0.001F);
		}
		if (souffle < 100.0F)
		{
			souffle += 0.35F;
		}
		if (baloon.transform.localScale.x > 3)
		{
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
			Destroy(baloon);
		}
	}
}
