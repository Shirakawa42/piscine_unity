using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_exit : MonoBehaviour {

	public trigger_exit[]		triggers;
	public bool					triggered;
	public bool					all_ok;
	public string				target_name;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == target_name)
		{
			triggered = true;
			all_ok = true;
			foreach (trigger_exit trigger in triggers)
			{
				if (trigger.triggered == false)
				{
					all_ok = false;
					break ;
				}
			}
			if (all_ok)
			{
				Debug.Log("Exit triggered !");
			}
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == target_name)
			triggered = false;
	}
}
