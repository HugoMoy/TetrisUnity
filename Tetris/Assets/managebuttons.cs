using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managebuttons : MonoBehaviour {

	public void NewGameButton(string NewGameLevel) {
		SceneManager.LoadScene(NewGameLevel);
	}

	public void MainMenuButton(string NewGameLevel) {
		SceneManager.LoadScene(NewGameLevel);
	}

	public void ExitGameButton(){
		Application.Quit();
	} 
}
