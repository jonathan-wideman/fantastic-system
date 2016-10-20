using UnityEngine;
using System.Collections;

public class PopupManager : MonoBehaviour {

	[SerializeField]
	TextPopup interactionHintPrefab;
	[SerializeField]
	TextPopup damageTextPrefab;

	public TextPopup Damage(float damage, Vector3 position, Transform parentTo = null) {
		TextPopup popup = CreatePopup (damageTextPrefab, position, parentTo);
		popup.textComponent.text = "" + damage;
		return popup;
	}

	public TextPopup InteractionHint(string text, Vector3 position, Transform parentTo = null) {
		TextPopup popup = CreatePopup (interactionHintPrefab, position, parentTo);
		popup.textComponent.text = text;
		return popup;
	}

	TextPopup CreatePopup(TextPopup prefab, Vector3 position, Transform parentTo = null) {
		TextPopup popup = Instantiate (prefab);
		if (parentTo != null) {
			popup.transform.SetParent (parentTo);
			popup.transform.localPosition = position;
		} else {
			popup.transform.position = position;
		}
		return popup;
	}

}
