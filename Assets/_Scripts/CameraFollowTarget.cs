using UnityEngine;
using System.Collections;

public class CameraFollowTarget : MonoBehaviour {

	public Transform target;
	public float lerp;
	Vector3 focus;
	Vector3 offset;

	void Start () {
		if (target != null) {
			FocusOn (target);
			ResetOffset ();
		}
	}

	void ResetOffset () {
		offset = transform.position - target.position;
	}

	void FocusOn (Transform target) {
		this.target = target;
		focus = target.position;
	}

	void LateUpdate () {
		if (target != null) {
			focus = Vector3.Lerp (target.position, focus, lerp);
			transform.position = focus + offset;
		}
	}
}
