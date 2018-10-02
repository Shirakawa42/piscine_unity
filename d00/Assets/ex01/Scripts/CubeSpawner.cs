using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject		original1;
	public GameObject		original2;
	public GameObject		original3;
	private float			time;
	private GameObject		cpy;
	private int				tmp_type;
	private double 			i;

	// Use this for initialization
	void Start () {
		time = Random.Range(60.0f, 120.0f);
	}
	
	// Update is called once per frame
	void Update () {
		time -= 0.5f;;
		if (time <= 0.0f && !cpy)
		{
			time = Random.Range(90.0f, 100.0f);
			tmp_type = Random.Range(1, 4);
			if (tmp_type == 1)
			{
				cpy = Instantiate(original1, new Vector3(-5.2F, 6.41F, 0.0F), Quaternion.identity);
			}
			else if (tmp_type == 2)
			{
				cpy = Instantiate(original2, new Vector3(0.0F, 6.41F, 0.0F), Quaternion.identity);
			}
			else if (tmp_type == 3)
			{
				cpy = Instantiate(original3, new Vector3(5.2F, 6.41F, 0.0F), Quaternion.identity);
			}
		}
		if (cpy && Input.GetKeyDown("a") && cpy.transform.position.x == -5.2f && cpy.transform.position.y <= -2.80F && cpy.transform.position.y >= -5.20F)
		{
			Debug.Log("Precision: " + (((i = (100*(cpy.transform.position.y + 3.5))) > 0) ? i : -i));
			GameObject.Destroy(cpy);
		}
		if (cpy && Input.GetKeyDown("s") && cpy.transform.position.x == 0.0f && cpy.transform.position.y <= -2.80F && cpy.transform.position.y >= -5.20F)
		{
			Debug.Log("Precision: " + (((i = (100*(cpy.transform.position.y + 3.5))) > 0) ? i : -i));
			GameObject.Destroy(cpy);
		}
		if (cpy && Input.GetKeyDown("d") && cpy.transform.position.x == 5.2f && cpy.transform.position.y <= -2.80F && cpy.transform.position.y >= -5.20F)
		{
			Debug.Log("Precision: " + (((i = (100*(cpy.transform.position.y + 3.5))) > 0) ? i : -i));
			GameObject.Destroy(cpy);
		}
		if (cpy && cpy.transform.position.y < -5.30f)
		{
			GameObject.Destroy(cpy);
		}
	}
}
