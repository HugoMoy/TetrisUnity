using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGroupPanel : MonoBehaviour {
	public static int w = 12;
	public static int h = 4;
	public static Transform[,] grid = new Transform[w, h];

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x == 12 && (int)pos.y == 10);
	}
}
