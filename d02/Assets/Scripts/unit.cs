using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour {

	public int			HP;
	public int			maxHP;
	public float		AttackSpeed;
	public bool			isSpawner;
	public unit			unitType;
	public selection	list;
	public unit			cloned;
	public bool			is_orc;

	// Use this for initialization
	void Start () {
		if (isSpawner == true)
			InvokeRepeating("Spawn", 10.0f, 10.0f);
	}

	void Spawn () {
		float	position = (is_orc) ? -1.5f : 1.5f;
		cloned = Instantiate(unitType, new Vector3(transform.position.x + position, transform.position.y - 1.5f, 0.0f), Quaternion.identity);
		cloned.list = list;
		if (!is_orc)
			cloned.GetComponent<unit_movement_01>().list = list;
	}

	void Update () {
		if (HP <= 0)
			Destroy(this);
	}
}
