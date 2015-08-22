using UnityEngine;
using System.Collections;

[System.Serializable]
public class YBoundary{
	public float yMin, yMax;
}

public class PlayerScript : MonoBehaviour {

	public float speed;
	public YBoundary yBoundary;

	void FixedUpdate () {
		if (Input.GetKey ("up")) {
			if(!(transform.position.y+0.01f > yBoundary.yMax)){
				transform.Translate (0,0.1f,0);
			}

		}else if (Input.GetKey("down")){
			if(!(transform.position.y-0.01f < yBoundary.yMin)){
				transform.Translate (0,-0.1f,0);
			}
		}
	}

	void OnCollisionEnter2D(){
		this.transform.position = new Vector2 (0,-4.5f);
	}
	
}
