using UnityEngine;
using System.Collections;

public class BeginBattleInteractable : Interactable {

	public BattleController battle;

	public override void Interact () {
		Debug.Log ("Beginning Battle...");
		battle.Begin ();
	}

}
