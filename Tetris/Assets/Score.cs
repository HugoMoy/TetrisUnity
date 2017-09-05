using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//Based on http://tetris.wikia.com/wiki/Scoring

	private static int pointsForOneLine = 40;
	private static int pointsForTwoLine = 100;
	private static int pointsForThreeLine = 300;
	private static int pointsForFourLine = 1200;
	private static int level = 1;
	private static int pointsTotal = 0;

	Text instruction;
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instruction.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		instruction.text = "Score: " + pointsTotal;
	}

	public static void addPoints(int lines) {
		
		switch(lines) {
		case 1:
			pointsTotal += pointsForOneLine * level;
			break;
		case 2:
			pointsTotal += pointsForTwoLine * level;
			break;
		case 3:
			pointsTotal += pointsForThreeLine * level;
			break;
		case 4:
			pointsTotal += pointsForFourLine * level;
			break;
		default:
			pointsTotal += 0;
			break;
		}			
	}

	public static int getPointsTotal() {
		return pointsTotal;
	}
}
