using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGO : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int points = Score.getPointsTotal();
		Text instruction = GetComponent<Text>();
		instruction.text = "Score : " + points;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
