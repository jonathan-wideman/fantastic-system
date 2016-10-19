using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {


	bool hinted;

	public Transform hintPrefab;
	public Vector3 hintOffset;
	Transform hintObject;

	public void Interact () {
		Debug.Log ("interacting with " + this);
	}

	public void Hint () {
		//Debug.Log ("hint!");
		if (hinted == false) {
			hinted = true;
			hintObject = Instantiate (hintPrefab, transform.position + hintOffset, transform.rotation) as Transform;//, transform);
		}	
	}

	public void Unhint () {
		//Debug.Log ("unhint!");
		hinted = false;
		if (hintObject != null) {
			Destroy (hintObject.gameObject);
		}
	}
}
