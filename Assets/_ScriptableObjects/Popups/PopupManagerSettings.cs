using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PopupManager Settings", menuName = "Popups/PopupManager Settings", order = 1)]
public class PopupManagerSettings : ScriptableObject {
	public TextPopup textPopupPrefab;
	public TextPopupStyle damagePopupStyle;
	public TextPopupStyle interactnHintPopupStyle;
}
