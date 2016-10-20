using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour {

	GameController game;

	public bool complete;
	public int roundCount;
	public int turnCount;

	public Team[] teams;

	Team winner;

	List<Battler> turnOrder;

	void Start () {
		game = GameController.Instance ();
	}

	public void Begin () {
		if (complete == false) {
			game.state = GameController.GameState.Battle;
			turnCount = 0;
			roundCount = 0;
			winner = null;
			CreateTurnOrder ();

			StartCoroutine (ProcessBattle ());
		} else {
			Debug.LogWarning ("Tried to begin a completed battle: " + this);
		}
	}

	IEnumerator ProcessBattle () {
		Debug.Log ("======== BATTLE BEGINS ========");

		Battler currentBattler;
		while (complete == false) {
			if (turnCount % turnOrder.Count == 0) {
				// all battlers have taken their turn; increment rounds
				turnCount = 0;
				roundCount += 1;
				Debug.Log ("====== ROUND " + roundCount + " ======");
			}
			// increment turns
			turnCount += 1;

			// get current battler in trun order and take them out of the order
			currentBattler = turnOrder [0];
			turnOrder.RemoveAt (0);

			// take their turn
			Debug.Log("---- TURN" + turnCount + ": " + currentBattler.nickname + " ----");
			//Debug.Log ("[space]");
			//yield return null;
			//yield return new WaitUntil (() => Input.GetButtonDown ("Jump"));
			ProcessTurn (currentBattler);
			Debug.Log ("[space]");
			yield return null;
			yield return new WaitUntil (() => Input.GetButtonDown ("Jump"));

			// add them back at the end of the order
			turnOrder.Add (currentBattler);

			if (CheckForWinner (out winner) == true) {
				complete = true;
			}
		}

		HandleAftermath ();
	}

	void HandleAftermath () {
		Debug.Log ("======== BATTLE COMPLETED ========");
		Debug.Log (winner.nickname + " is the winner!");
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

	void CreateTurnOrder () {
		turnOrder = new List<Battler> ();
		List<Battler> turns = new List<Battler> ();
		for (int i = 0; i < teams.Length; i++) {
			for(int j = 0; j < teams[i].battlers.Length; j++) {
				turns.Add(teams[i].battlers[j]);
			}
		}

		int index;
		while (turns.Count > 0) {
			index = Random.Range (0, turns.Count);
			turnOrder.Add (turns [index]);
			turns.RemoveAt (index);
		}
	}

	void ProcessTurn (Battler battler) {
		List<Battler> targets = new List<Battler> ();
		for (int i = 0; i < teams.Length; i++) {
			if (teams [i] != battler.team) {
				targets.AddRange (teams [i].battlers);
			}
		}

		// pick random target
		Battler target = targets[Random.Range(0, targets.Count)];

		// attack target
		battler.Attack(target);
	}
}
