using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_exit_ex02 : MonoBehaviour {

	public trigger_exit_ex02[]		triggers;
	public bool					triggered;
	public bool					all_ok;
	public string				target_name;
	public playerScript_ex01[]	players;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == target_name)
		{
			triggered = true;
			all_ok = true;
			foreach (trigger_exit_ex02 trigger in triggers)
			{
				if (trigger.triggered == false)
				{
					all_ok = false;
					break ;
				}
			}
			if (all_ok)
			{
				if (players.Length == 0)
					Debug.Log("Exit triggered !");
				foreach (playerScript_ex01 player in players)
				{
					player.basex += 53.0f;
					player.transform.position = new Vector3(player.basex, player.basey, 0.0f);
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == target_name)
			triggered = false;
	}
}
