﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreTextPlayerOne;
	public Text scoreTextPlayerTwo;
	public Text centralText;
	public Text winnerText;
	public int scorePlayerOne;
	public int scorePlayerTwo;
	public int startTimeInSec;
	public int maxTimeInSec;
	public int pauseTimeEnd;
	private bool start;
	public GameController current;
	public GameObject player1;
	public GameObject player2;
	bool showCountdown;

	void Start () {
		start = false;
		current = this;
		scorePlayerOne = 0;
		scorePlayerTwo = 0;
		maxTimeInSec = 60;
		pauseTimeEnd = 5;
		UpdateScore ();
		StartCoroutine(Countdown());	
	}

	IEnumerator Countdown()
	{
		centralText.text = "3";
		yield return new WaitForSeconds(1);
		centralText.text = "2";
		yield return new WaitForSeconds(1);
		centralText.text = "1";
		yield return new WaitForSeconds(1);
		centralText.text = "Go!!!";
		yield return new WaitForSeconds(1);
		centralText.text = "";
	}

	void Update(){
		float actualTime = Time.timeSinceLevelLoad;
		if (!start && actualTime > startTimeInSec) {
			start = true;
			player1.SetActive (true);
			player2.SetActive (true);
		}else if(actualTime > (maxTimeInSec + pauseTimeEnd)){
			Application.LoadLevel(3);
		}else if (actualTime > maxTimeInSec) {
			if(scorePlayerOne > scorePlayerTwo){
				scoreTextPlayerOne.text = ":)";
				scoreTextPlayerTwo.text = ":(";
				winnerText.text="Player 1 wins";
			}else if(scorePlayerTwo > scorePlayerOne){
				scoreTextPlayerOne.text = ":(";
				scoreTextPlayerTwo.text = ":)";
				winnerText.text="Player 2 wins";
			}else{
				scoreTextPlayerOne.text = ":|";
				scoreTextPlayerTwo.text = ":|";
				winnerText.text="DRAW";
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