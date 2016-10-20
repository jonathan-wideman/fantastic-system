using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPopup : MonoBehaviour {

	public bool expired = false;
	public Text textComponent;

	float expireTime;
	TextPopupStyle style;

	void OnEnable () {
		textComponent = GetComponentInChildren<Text> ();
	}

	public void ApplyStyle (TextPopupStyle style) {
		this.style = style;
		expireTime = Time.time + style.lifetime;
	}

	void Update () {
		if (expired == false) {
			if (Time.time >= expireTime) {
				Expire ();
			}
			transform.Translate (style.velocity * Time.deltaTime, Space.World);
		}
	}
	
	void LateUpdate () {
		if (style.billboard) {
			Billboard ();
		}
	}

	void Billboard () {
		transform.LookAt (2 * transform.position - Camera.main.transform.position);
	}

	void Expire () {
		expired = true;
		if (style.destroyOnExpire) {
			Destroy (gameObject);
		}
	}
}
