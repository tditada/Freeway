using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreTextPlayerOne;
	public Text scoreTextPlayerTwo;
	public int scorePlayerOne;
	public int scorePlayerTwo;
	public GameController current;

	void Start () {
		current = this;
		scorePlayerOne = 0;
		scorePlayerTwo = 0;
		UpdateScore ();
	}

	public void AddScore(int newScore, int player){
		if (player == 1) {
			scorePlayerOne += newScore;
		} else if (player == 2) {
			scorePlayerTwo += newScore;
		} else {
			Debug.Log ("wrong player");
		}
		UpdateScore ();
	}

	void UpdateScore () {
		scoreTextPlayerOne.text = "Score: " + scorePlayerOne;
		scoreTextPlayerTwo.text = "Score: " + scorePlayerTwo;
	}
}
