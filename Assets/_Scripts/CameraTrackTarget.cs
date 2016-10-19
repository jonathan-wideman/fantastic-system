using UnityEngine;
using System.Collections;

public class CameraTrackTarget : MonoBehaviour {

	public Transform target;
	public float lerp;
	Vector3 focus;

	void Start () {
		if (target != null) {
			FocusOn (target);
		}
	}

	void FocusOn (Transform target) {
		this.target = target;
		focus = target.position;
	}

	void LateUpdate () {
		if (target != null) {
			focus = Vector3.Lerp (target.position, focus, lerp);
			transform.LookAt (focus);
		}
	}
}
