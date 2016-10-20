using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	bool hinted;

	public string hintText;
	public Vector3 hintOffset;
	Transform hintObject;

	GameController game;

	void Start () {
		game = GameController.Instance ();
	}

	public virtual void Interact () {
		Debug.Log ("interacting with " + this);
	}

	public void Hint () {
		if (hinted == false) {
			hinted = true;
			hintObject = game.popups.InteractionHint(hintText, transform.position + hintOffset).transform;
		}	
	}

	public void Unhint () {
		hinted = false;
		if (hintObject != null) {
			Destroy (hintObject.gameObject);
		}
	}
}
