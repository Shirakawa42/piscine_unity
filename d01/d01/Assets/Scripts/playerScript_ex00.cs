using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

	public float				jump_power;
	public bool					selected;
	public string				name;
	public string				key;
	public float				speed;
	public playerScript_ex00[]	others;
	public Rigidbody2D			rb;
	private float				moveH;
	private float				moveV;
	private Vector2				move;
	public float				basex;
	public float				basey;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected && Input.GetKeyDown("r"))
		{
			foreach (playerScript_ex00 other in others)
			{
				other.transform.position = new Vector3(other.basex, other.basey, 0.0f);
				other.rb.velocity = new Vector2(0.0f, 0.0f);
			}
			transform.position = new Vector3(basex, basey, 0.0f);
			rb.velocity = new Vector2(0.0f, 0.0f);
		}
		if (Input.GetKeyDown(key))
		{
			foreach (playerScript_ex00 other in others)
			{
				other.selected = false;
			}
			selected = true;
		}
		if (Input.GetKey("right") && selected)
		{
			moveH = speed;
		}
		else if (Input.GetKey("left") && selected)
		{
			moveH = -speed;
		}
		else
		{
			moveH = 0.0f;
		}
		if (Input.GetKeyDown("space") && rb.velocity[1] == 0.0f && selected)
		{
			moveV = jump_power;
		}
		else
		{
			moveV = rb.velocity[1];
		}
		rb.velocity = new Vector2(moveH, moveV);
	}
}
