using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "TextPopupStyle", menuName = "Popups/Text Popup Style", order = 2)]
public class TextPopupStyle : ScriptableObject {
	public bool billboard = true;
	public float lifetime = 1f;
	public bool destroyOnExpire = true;
	public Vector3 velocity;
}
