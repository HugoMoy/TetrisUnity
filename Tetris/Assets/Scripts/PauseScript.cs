using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
	GameObject[] pauseObjects;
	GameObject[] gameplayObjects;

	bool isGameover = false;
	bool gameoverisActivated = false;
	// Use this for initialization

	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		gameplayObjects = GameObject.FindGameObjectsWithTag("Gameplay");
		hidePaused();

		isGameover = false;
		gameoverisActivated = false;
	}

	// Update is called once per frame
	void Update () {
//		if (gameoverisActivated)
//			return;

		if (isGameover) {
			gameoverisActivated = true;
			hideGameplay();

			if(Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene("StartScene");
			}

			return;
		} 

		if(Input.GetKeyDown(KeyCode.P)) {
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
//				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}
		
	public void unpaused() {
		Time.timeScale = 1;
		hidePaused();
		return;
	}

	public void setGameover(bool value) {
		isGameover = value;
	}

	//Reloads the Level
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}

	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}

		gameplayObjects = GameObject.FindGameObjectsWithTag("Gameplay");
		foreach(GameObject g in gameplayObjects){
			g.SetActive(false);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}

		foreach(GameObject g in gameplayObjects){
			g.SetActive(true);
		}
	}

	public void hideGameplay(){
		gameplayObjects = GameObject.FindGameObjectsWithTag("Gameplay");
		foreach(GameObject g in gameplayObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}
}
