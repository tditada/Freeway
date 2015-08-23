using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreTextPlayerOne;
	public Text scoreTextPlayerTwo;
	public int scorePlayerOne;
	public int scorePlayerTwo;
	public int maxTimeInSec;
	public int pauseTimeEnd;
	public GameController current;
	public GameObject player1;
	public GameObject player2;


	void Start () {
		current = this;
		scorePlayerOne = 0;
		scorePlayerTwo = 0;
		maxTimeInSec = 10;
		pauseTimeEnd = 3;
		UpdateScore ();
	}
	

	void Update(){
		float actualTime = Time.timeSinceLevelLoad;

		if(actualTime > (maxTimeInSec + pauseTimeEnd)){
			Application.LoadLevel(2);
		}else if (actualTime > maxTimeInSec) {
			if(scorePlayerOne > scorePlayerTwo){
				scoreTextPlayerOne.text = "WINNER";
				scoreTextPlayerTwo.text = ":(";
			}else if(scorePlayerTwo > scorePlayerOne){
				scoreTextPlayerOne.text = ":(";
				scoreTextPlayerTwo.text = "WINNER";
			}else{
				scoreTextPlayerOne.text = "DRAW";
				scoreTextPlayerTwo.text = "DRAW";
			}
			player2.SetActive(false);
			player1.SetActive(false);
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
