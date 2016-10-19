using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Transform interactHint;
	public LayerMask interactMask;
	public float interactRange;
	public float interactSnapRange;

	CharacterController charControl;
	Vector3 movementInput = Vector3.zero;

	Interactable interactTarget;

	// Use this for initialization
	void Start () {
		charControl = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		movementInput.x = Input.GetAxis ("Horizontal");
		movementInput.z = Input.GetAxis ("Vertical");
		charControl.SimpleMove (movementInput.normalized * speed);

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, transform.position);
		float hitDistance;
		if (groundPlane.Raycast (ray, out hitDistance)) {
			Vector3 point = ray.GetPoint (hitDistance);
			//Debug.DrawLine (ray.origin,point, Color.red);
			LookAt(point);

			if (Vector3.Distance (point, transform.position) <= interactRange) {
				interactHint.position = point;
				interactHint.gameObject.SetActive (true);

				Collider[] hits = Physics.OverlapSphere (point, 3f);
				float minDistFromCursor = interactRange;
				for (int i = 0; i < hits.Length; i++) {
					if (Vector3.Distance (hits [i].transform.position, transform.position) < interactRange) {
						float distFromCursor = Vector3.Distance (hits [i].transform.position, point);
						if (distFromCursor < minDistFromCursor) {
							Interactable interact = hits [i].GetComponentInParent<Interactable> ();
							if (interact != null) {
								interactTarget = interact;
								interactHint.position = interactTarget.transform.position;
								minDistFromCursor = distFromCursor;
							}
						}
					}
				}
			} else {
				interactHint.gameObject.SetActive (false);
			}

			/*
			float distance = Vector3.Distance (point, transform.position);
			if (distance <= interactRange) {
				interactTarget.position = point;
				interactTarget.gameObject.SetActive (true);
			} else if (distance <= interactSnapRange) {
				interactTarget.position = transform.position + (point - transform.position).normalized * interactRange;
				interactTarget.gameObject.SetActive (true);
			} else {
				interactTarget.gameObject.SetActive (false);
			}
			*/


			if (Input.GetButtonDown("Fire1") && interactTarget != null) {
				//Debug.Log ("interacting");
				interactTarget.Interact();
			}
		}
	}

	public void LookAt (Vector3 lookPoint) {
		lookPoint.y = transform.position.y;
		transform.LookAt (lookPoint);
	}
}
