using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	GameController game;

	public bool complete;
	public int turnCount;

	public Team[] teams;

	Team winner;

	void Start () {
		game = GameController.Instance ();
	}

	public void Begin () {
		if (complete == false) {
			game.state = GameController.GameState.Battle;
			turnCount = 0;
			winner = null;
			StartCoroutine (TakeTurns ());
		} else {
			Debug.LogWarning ("Tried to begin a completed battle: " + this);
		}
	}

	IEnumerator TakeTurns () {
		while (complete == false) {
			Debug.Log ("Beginning turn " + turnCount);
			Debug.Log ("press space...");
			yield return null;
			yield return new WaitUntil (() => Input.GetButtonDown ("Jump"));

			turnCount += 1;

			if (CheckForWinner (out winner) == true) {
				complete = true;
			}
		}

		HandleAftermath ();
	}

	void HandleAftermath () {
		Debug.Log ("Battle completed; " + winner.nickname + " is the winner!");
		Debug.Log ("Returning to Field mode.");
		game.state = GameController.GameState.Field;
	}

	bool CheckForWinner (out Team winner) {
		winner = null;
		for (int i = 0; i < teams.Length; i++) {
			if (teams [i].IsDefeated () == false) {
				if (winner == null) {
					// there's no undefeated teams yet; record this team as undefeated
					winner = teams [i];
				} else {
					// there's already an undefeated team; battle isn't over yet
					winner = null;
					return false;
				}
			}
		}
		// At this point, either:
		//  there is exactly one undefeated team; the battle is over
		//  or there is no undefeated team; battle ends as draw
		return true;
	}
}
