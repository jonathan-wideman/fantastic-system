using UnityEngine;
using System.Collections;

public class Team : MonoBehaviour {

	public string nickname;
	public Battler [] battlers;

	public bool IsDefeated () {
		for (int i = 0; i < battlers.Length; i++) {
			if (battlers [i].defeated == false) {
				return false;
			}
		}
		// either we have no battlers or they are all defeated;
		// this team is defeated
		return true;
	}
}
