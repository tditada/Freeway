using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

	int sceneBefore;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void setSceneBefore(int scene){
		sceneBefore = scene;
	}

	public int getSceneBefore(){
		return sceneBefore;
	}
}