using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	public towerScript		tower;
	public gameManager		GM;
	private Vector3			position;
	private Ray				ray;
	private bool			taken;
	private SpriteRenderer	sprite;
	private Vector3			placing;

	void OnMouseDown () {
		if (Input.GetMouseButtonDown(0) && GM.playerEnergy >= tower.energy)
			taken = true;
	}

	void Start () {
		taken = false;
		position = transform.position;
		sprite = GetComponent<SpriteRenderer>();
		placing = new Vector3(0.0f, 0.0f, 0.0f);
	}

	private bool	checkPosition() {
		RaycastHit2D	hit = Physics2D.Raycast(ray.origin, Vector2.zero);
		if (hit && hit.collider.tag == "empty")
		{
			placing = hit.collider.transform.position;
			hit.collider.tag = "full";
			return true;
		}
		return false;
	}

	void Update () {
		if (taken)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			ray.origin = new Vector3(ray.origin.x, ray.origin.y, 0.0f);
			transform.position = ray.origin;
		}
		if (taken && Input.GetMouseButtonUp(0))
		{
			taken = false;
			transform.position = position;
			if (GM.playerEnergy >= tower.energy && checkPosition())
			{
				GM.playerEnergy -= tower.energy;
				Instantiate(tower, placing, Quaternion.identity);
			}
		}
		if (GM.playerEnergy < tower.energy && sprite.color != Color.red)
			sprite.color = Color.red;
		else if (sprite.color != Color.white && GM.playerEnergy >= tower.energy)
			sprite.color = Color.white;
	}
}
