using UnityEngine;
using System.Collections;

public class MovingCars : MonoBehaviour {

	public float speed = 5f;

	void Update () {
		transform.Translate (0, speed * Time.deltaTime,0);
	}

	void OnBecameInvisible(){
		gameObject.SetActive (false);
	}
}
