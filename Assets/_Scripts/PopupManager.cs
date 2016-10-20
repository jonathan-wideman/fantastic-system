using UnityEngine;
using System.Collections;

public class PopupManager : MonoBehaviour {

	public TextPopup damageTextPrefab;

	public TextPopup Damage(float damage, Vector3 position, Transform parentTo = null) {
		TextPopup popup = Instantiate (damageTextPrefab);
		if (parentTo != null) {
			popup.transform.SetParent (parentTo);
			popup.transform.localPosition = position;
		} else {
			popup.transform.position = position;
		}
		popup.textComponent.text = "" + damage;
		return popup;
	}

}
