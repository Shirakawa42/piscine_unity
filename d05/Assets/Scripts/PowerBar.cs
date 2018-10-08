using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

	public ballScript 	ball;
	public GameObject 	arrowPrefab;
	public cameraController 	camera;
	public bool 		free = true;
	public bool 		active = false;

	private float		current_power = 0.0f;
	private float 		increasing_power = 0.015f;
	private Image 		image;
	private GameObject 	arrow;

	void Start () {
		image = GetComponent<Image>();
	}

	void setPower(float power) {
		image.fillAmount = current_power;
	}
	
	void Update () {
		if (free)
		{
			if (Input.GetKeyDown("space") && !active && !ball.isMoving)
			{
				active = true;
				camera.free = false;
				camera.transform.position = ball.transform.position;
				camera.transform.LookAt(camera.actual_hole.transform);
				camera.transform.position += -camera.transform.forward * 2.0f + camera.transform.up;
				arrow = Instantiate(arrowPrefab, ball.transform.position + new Vector3(0.0f, 0.5f, -1.5f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
				arrow.GetComponent<arrowScript>().ball = ball.gameObject;
			}
			else if (Input.GetKeyDown("space") && active)
			{
				Destroy(arrow);
				active = false;
				ball.shoot(current_power, arrow);
				current_power = 0.0f;
				increasing_power = 0.015f;
				setPower(current_power);
				camera.free = true;
			}
			if (active == true)
			{
				current_power += increasing_power;
				setPower(current_power);
				if (current_power >= 1.0f || current_power <= 0.0f)
					increasing_power = -increasing_power;
			}
		}
	}
}
