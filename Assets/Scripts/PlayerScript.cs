using UnityEngine;
using System.Collections;

[System.Serializable]
public class YBoundary{
	public float yMin, yMax;
}

public class PlayerScript : MonoBehaviour {

	public float speed = 100;
	public float step = 0.07f;
	public float offset = 0.01f;
	public int addScore = 1;
	public YBoundary yBoundary;
	GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (!gameController) {
			Debug.Log ("Cannot Find GameController Instance");
		}
	}

	void Update(){
		if (transform.position.y >= yBoundary.yMax-offset) {
			gameController.current.AddScore(addScore);
			MoveToStart ();
		}
	}

	void FixedUpdate () {

		if (Input.GetKey ("up")) {
			if(!(transform.position.y+step > yBoundary.yMax)){
				transform.Translate (0,step,0);
			}

		}else if (Input.GetKey("down")){
			if(!(transform.position.y-step < yBoundary.yMin)){
				transform.Translate (0,(-1)*step,0);
			}
		}
	}

	void OnCollisionEnter2D(){
		MoveToStart ();
		//gameController.AddScore ((-1) * addScore);
	}

	void MoveToStart(){
		this.transform.position = new Vector2 (0,yBoundary.yMin);
	}
	
}
