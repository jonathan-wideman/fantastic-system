using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameState state;
	public PopupManager popups;

	public enum GameState
	{
		Field,
		Battle
	}

	public static GameController Instance () {
		GameController game = FindObjectOfType<GameController> ();
		if (game == null) {
			GameObject go = new GameObject ("GameController");
			go.tag = "GameController";
			game = (GameController) go.AddComponent (typeof (GameController));
		}
		return game;
	}

	// Use this for initialization
	void Start () {
		popups = FindObjectOfType<PopupManager> ();
		state = GameState.Field;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
