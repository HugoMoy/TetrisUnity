using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGroup : MonoBehaviour {
	public static int w = 10;
	public static int h = 20;
	public static Transform[,] grid = new Transform[w, h];

	GameObject next = null;
	GameObject prev = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showNextGroup() {
		if (prev != null) {
			Destroy(this.prev.gameObject);
		}
		
		next = FindObjectOfType<Spawner>().getNextGroupToShow();
		next.transform.position = transform.position;
		prev = Instantiate(next, transform.position, Quaternion.identity);	
	}
}
