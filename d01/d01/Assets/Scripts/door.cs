using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

	public float	distance;

	public void	open()
	{
		transform.Translate(new Vector3(0.0f, distance, 0.0f));
	}

	public void	close()
	{
		transform.Translate(new Vector3(0.0f, -distance, 0.0f));
	}
}
