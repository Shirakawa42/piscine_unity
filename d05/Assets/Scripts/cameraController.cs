using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	public float 		speed = 1.0f;
	public GameObject 	ball;
	public GameObject 	actual_hole;
	public bool 		free = true;
	public PowerBar 	PB;

	private float	yRotation;
	private float 	xRotation;
	private float	rotateSpeed = 3.0f;
	private GameObject current_target;

	bool hit(Vector3 vec) {
		RaycastHit hit;
		Ray landingRay = new Ray(transform.position, vec);

		if (Physics.Raycast(landingRay, out hit, 2))
			return (true);
		return (false);
	}

	void Update () {
		if (free) {
			yRotation -= Input.GetAxis("Mouse Y") * rotateSpeed;
			yRotation = Mathf.Clamp(yRotation, -80, 80);
			xRotation += Input.GetAxis("Mouse X") * rotateSpeed;
			xRotation = xRotation % 360;
			transform.localEulerAngles = new Vector3(yRotation, xRotation, 0);
			if (Input.GetKey("z") && !hit(transform.forward * speed) && (transform.position + transform.forward * speed).y < 160)
				transform.position += transform.forward * speed;
			if (Input.GetKey("s") && !hit(-transform.forward * speed) && (transform.position - transform.forward * speed).y < 160)
				transform.position += -transform.forward * speed;
			if (Input.GetKey("d") && !hit(transform.right * speed) && (transform.position + transform.right * speed).y < 160)
				transform.position += transform.right * speed;
			if (Input.GetKey("q") && !hit(-transform.right * speed) && (transform.position - transform.right * speed).y < 160)
				transform.position += -transform.right * speed;
			if (Input.GetKeyDown("space") && PB.active)
			{
				transform.position = ball.transform.position;
				transform.LookAt(actual_hole.transform);
				transform.position += -transform.forward * 2.0f + transform.up;
				free = false;
				PB.free = true;
			}
		}
		else if (Input.GetKeyDown("f"))
		{
			free = true;
			PB.free = false;
		}
	}

}
