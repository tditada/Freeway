using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void OnClick(int level){
		Application.LoadLevel (level);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}