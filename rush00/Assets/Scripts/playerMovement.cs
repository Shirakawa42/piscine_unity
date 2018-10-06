using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float		speed = 5.0f;
	public GameObject	legs;
	private Rigidbody	rb;
	private Animator	anim;
	private float		moveH;
	private float		moveV;
	private Ray			ray;
	private int			floorMask;
	// Use this for initialization
	void Start () {
		floorMask = LayerMask.GetMask ("Floor");
		rb = GetComponent<Rigidbody>();
		anim = legs.GetComponent<Animator>();
	}

	void	faceMousePosition() {
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast (camRay, out floorHit, 20.0f, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y= 0.0f;
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
            rb.MoveRotation (newRotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
			moveV = speed;
		else if (Input.GetKey("s"))
			moveV = -speed;
		else
			moveV = 0.0f;
		if (Input.GetKey("a"))
			moveH = -speed;
		else if (Input.GetKey("d"))
			moveH = speed;
		else
			moveH = 0.0f;
		if (moveH != 0.0f || moveV != 0.0f)
			anim.SetTrigger("moving");
		else
			anim.ResetTrigger("moving");
		rb.velocity = new Vector3(moveH, 0.0f, moveV);
		faceMousePosition();
	}
}
