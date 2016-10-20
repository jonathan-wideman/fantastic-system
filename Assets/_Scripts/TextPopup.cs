using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPopup : MonoBehaviour {

	public bool billboard = true;
	public float lifetime = 1f;
	public bool destroyOnExpire = true;
	public bool expired = false;
	public Vector3 velocity;

	public Text textComponent;

	float expireTime;

	void OnEnable () {
		textComponent = GetComponentInChildren<Text> ();
		expireTime = Time.time + lifetime;
	}

	void Update () {
		if (expired == false) {
			if (Time.time >= expireTime) {
				Expire ();
			}

			transform.Translate (velocity * Time.deltaTime, Space.World);
		}
	}
	
	void LateUpdate () {
		if (billboard) {
			Billboard ();
		}
	}

	void Billboard () {
		transform.LookAt (Camera.main.transform);
	}

	void Expire () {
		expired = true;
		if (destroyOnExpire) {
			Destroy (gameObject);
		}
	}
}
