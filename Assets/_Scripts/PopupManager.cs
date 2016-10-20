using UnityEngine;
using System.Collections;

public class PopupManager : MonoBehaviour {

	[SerializeField]
	PopupManagerSettings settings;

	public TextPopup Damage(float damage, Vector3 position, Transform parentTo = null) {
		TextPopup popup = CreatePopup (position, parentTo);
		popup.ApplyStyle (settings.damagePopupStyle);
		popup.textComponent.text = "" + damage;
		return popup;
	}

	public TextPopup InteractionHint(string text, Vector3 position, Transform parentTo = null) {
		TextPopup popup = CreatePopup (position, parentTo);
		popup.ApplyStyle (settings.interactnHintPopupStyle);
		popup.textComponent.text = text;
		return popup;
	}

	TextPopup CreatePopup(Vector3 position, Transform parentTo = null) {
		TextPopup popup = Instantiate (settings.textPopupPrefab);
		if (parentTo != null) {
			popup.transform.SetParent (parentTo);
			popup.transform.localPosition = position;
		} else {
			popup.transform.position = position;
		}
		return popup;
	}

}
