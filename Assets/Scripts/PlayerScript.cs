using UnityEngine;
using System.Collections;

[System.Serializable]
public class YBoundary{
	public float yMin, yMax;
}

public class PlayerScript : MonoBehaviour {

	public float speed = 100;
	public float step = 0.07f;
	public YBoundary yBoundary;

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
		this.transform.position = new Vector2 (0,yBoundary.yMin);
	}
	
}
