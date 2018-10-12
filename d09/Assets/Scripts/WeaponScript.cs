using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	public GameObject	particle;
	public AudioSource	shotSound;
	public float		cooldown;
	public float		recul;
	public float		lineSize;

	private bool 		canShoot = true;
	private GameObject 	cpy;

	private IEnumerator	removeLine (LineRenderer line) {
		yield return new WaitForSeconds(1f);
        Destroy(line);
	}

	private void	createLine (Vector3 start, Vector3 end) {
		LineRenderer	line;

		line = cpy.gameObject.AddComponent<LineRenderer>();
		line.SetWidth(lineSize, lineSize);
		line.SetVertexCount(2);
		line.SetPosition(0, start);
        line.SetPosition(1, end);
        StartCoroutine(removeLine(line));
	}

	private void	SetCanShoot () {
		canShoot = true;
	}

	private void	shoot() {
		RaycastHit 	hit;

		if (Physics.Raycast(transform.position, transform.parent.forward, out hit, 100)) {
			cpy = Instantiate(particle, hit.point, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
			createLine(transform.position, hit.point);
		}
		shotSound.Play();
		canShoot = false;
		Invoke("SetCanShoot", cooldown);
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - recul);
	}

	void Update () {
		if (Input.GetMouseButton(0) && canShoot)
			shoot();
		if (transform.localPosition.z < 1.388352f)
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + (recul * 5 * Time.deltaTime));
	}
}
