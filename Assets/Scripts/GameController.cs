using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public int score;
	public GameController current;

	void Start () {
		current = this;
		score = 0;
		UpdateScore ();
	}

	public void AddScore(int newScore){
		score += newScore;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}
}
