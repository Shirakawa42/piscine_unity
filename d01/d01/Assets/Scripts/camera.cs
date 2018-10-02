using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public playerScript_ex00[]	players;
	private playerScript_ex00	selected_player;
	// Use this for initialization
	void Start () {
		foreach (playerScript_ex00 player in players)
		{
			if (player.selected == true)
			{
				selected_player = player;
				break ;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (selected_player.selected)
			transform.position = new Vector3(selected_player.transform.position.x + 3.0f, selected_player.transform.position.y + 2.0f, -10.0f);
		else
		{
			foreach (playerScript_ex00 player in players)
			{
				if (player.selected == true)
				{
					selected_player = player;
					break ;
				}
			}
		}
	}
}
