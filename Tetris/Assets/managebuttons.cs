using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managebuttons : MonoBehaviour {

	public void NewGameButton(string NewGameLevel) {
		SceneManager.LoadScene(NewGameLevel);
	}

	public void MainMenuButton(string NewGameLevel) {
		SceneManager.LoadScene(NewGameLevel);
	}

	public void Unpaused() {
		FindObjectOfType<PauseScript>().unpaused();

	}

	public void ExitGameButton(){
		Application.Quit();
	} 
}
