using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed;
	public LayerMask interactMask;
	public float interactRange;
	public float roationLerp;
	public LayerMask groundMask;
	public float stickToGround;
	//int groundedFrames;
	//int framesBeforeGrounded = 45;

	List<Interactable> interactablesInRange;

	CharacterController charControl;
	Vector3 movementInput = Vector3.zero;

	Interactable interactTarget;

	GameController game;

	// Use this for initialization
	void Start () {
		game = GameController.Instance ();
		charControl = GetComponent<CharacterController> ();
		interactablesInRange = new List<Interactable> ();
	}

	// Update is called once per frame
	void Update () {

		if (game.state == GameController.GameState.Field) {

			// update movement input vector
			movementInput.x = Input.GetAxis ("Horizontal");
			movementInput.z = Input.GetAxis ("Vertical");

			// TODO: adjust movement to be relative to camera?

			// move the character
			charControl.SimpleMove (movementInput.normalized * speed);

			// stick to the ground
			/*
		if (charControl.isGrounded == false) {
			groundedFrames = 0;
		} else {
			groundedFrames += 1;
		}
		if (groundedFrames < framesBeforeGrounded) {
		*/

			if (charControl.isGrounded == false) {
				Ray ray = new Ray (transform.position, Vector3.down);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, stickToGround, groundMask)) {
					transform.Translate (Vector3.down * (hit.distance - charControl.skinWidth));
				}

				/*
			if (Physics.SphereCast(ray, charControl.radius, out hit, stickToGround, groundMask)) {
				//transform.Translate(Vector3.down * (hit.distance - charControl.skinWidth));
				transform.Translate(Vector3.down * stickToGround);
			}
			*/
			}

			// turn the character to face its movement
			if (movementInput != Vector3.zero) {
				transform.rotation = Quaternion.Lerp (Quaternion.LookRotation (movementInput.normalized, Vector3.up), transform.rotation, roationLerp);
			}

			// find all interactables in range
			Vector3 point = transform.position;
			float radius = interactRange;
			Collider[] hits = Physics.OverlapSphere (point, radius);

			for (int i = 0; i < hits.Length; i++) {
				Interactable interactable = hits [i].GetComponentInParent<Interactable> ();
				if (interactable != null) {
					interactTarget = interactable;
					interactablesInRange.Add (interactable);
				}
			}

			// find closest interactable and remove any out of range
			float closestDistance = interactRange;
			for (int j = 0; j < interactablesInRange.Count; j++) {
				float distance = Vector3.Distance (interactablesInRange [j].transform.position, point);
				if (distance < interactRange) {
					interactablesInRange [j].Hint ();
					if (distance < closestDistance) {
						interactTarget = interactablesInRange [j];
						closestDistance = distance;
					}
				} else {
					interactablesInRange [j].Unhint ();
					interactablesInRange.RemoveAt (j);
				}
			}

			// check the closest interactable and remove it if out of range
			// interact with it when a button is pressed
			if (interactTarget != null) {
				float distance = Vector3.Distance (interactTarget.transform.position, point);
				if (distance < interactRange) {
					Debug.DrawLine (transform.position, interactTarget.transform.position, Color.cyan, 0.01f);
					if (Input.GetButtonDown ("Interact")) {
						interactTarget.Interact ();
					}
				} else {
					interactTarget = null;
				}
			}
		}
	}
}
