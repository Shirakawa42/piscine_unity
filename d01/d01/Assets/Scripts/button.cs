using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	public door	target_door;
	public GameObject abutton;
	public bool	on;

	void OnTriggerStay2D (Collider2D other)
	{
		if (Input.GetKeyDown("e"))
		{
			if (!on)
			{
				target_door.open();
				abutton.transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
				on = true;
			}
			else
			{
				target_door.close();
				abutton.transform.Translate(new Vector3(0.0f, -0.5f, 0.0f));
				on = false;
			}
		}
	}
	
}
