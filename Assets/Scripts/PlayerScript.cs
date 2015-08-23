using UnityEngine;
using System.Collections;

[System.Serializable]
public class YBoundary{
	public float yMin, yMax;
}

[System.Serializable]
public class Players{
	public int player1, player2;
}

public class PlayerScript : MonoBehaviour {

	public float speed = 100;
	public float step = 0.07f;
	public float offset = 0.4f;
	public int addScore = 1;
	public string upKey = "up";
	public string downKey = "down";
	public int player;
	public AudioSource audio;

	public Players players;
	public YBoundary yBoundary;
	GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		audio = this.GetComponent<AudioSource> ();
		if (gameControllerObject) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (!gameController) {
			Debug.Log ("Cannot Find GameController Instance");
		}
	}

	void Update(){
		if (transform.position.y >= yBoundary.yMax-offset) {
			gameController.current.AddScore(addScore, player);
			MoveToStart ();
		}
	}

	void FixedUpdate () {

		if (Input.GetKey (upKey)) {
			if(!(transform.position.y+step > yBoundary.yMax)){
				transform.Translate (0,step,0);
			}

		}else if (Input.GetKey(downKey)){
			if(!(transform.position.y-step < yBoundary.yMin)){
				transform.Translate (0,(-1)*step,0);
			}
		}
	}

	void OnCollisionEnter2D(){
		MoveToStart ();
		audio.Play ();
		//gameController.AddScore ((-1) * addScore);
	}

	void MoveToStart(){
		if (player == players.player2) {
			this.transform.position = new Vector2 (3.5f, yBoundary.yMin);
		} else if (player == players.player1) {
			this.transform.position = new Vector2 (-3.5f, yBoundary.yMin);
		}

	}
	
}
