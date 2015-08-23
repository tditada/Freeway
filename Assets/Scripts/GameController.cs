using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreTextPlayerOne;
	public Text scoreTextPlayerTwo;
	public int scorePlayerOne;
	public int scorePlayerTwo;
	public int maxTimeInSec;
	public int game;
	public GameController current;


	void Start () {
		current = this;
		game = 1;
		scorePlayerOne = 0;
		scorePlayerTwo = 0;
		maxTimeInSec = 10;
		UpdateScore ();
	}

	void Update(){
		if (Time.timeSinceLevelLoad > maxTimeInSec) {
			if(scorePlayerOne > scorePlayerTwo){
				scoreTextPlayerOne.text = "Winner";
				scoreTextPlayerTwo.text = ":(";
			}else if(scorePlayerTwo > scorePlayerOne){
				scoreTextPlayerOne.text = ":(";
				scoreTextPlayerTwo.text = "Winner";
			}else{
				scoreTextPlayerOne.text = "DRAW";
				scoreTextPlayerTwo.text = "DRAW";
			}
			//Application.LoadLevel("MainScene");

		}
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
