using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Groups
	public GameObject[] groups;
	public GameObject nextGroup = null;

	// Use this for initialization
	void Start () {
		// Spawn initial Group
		spawnNext();
		FindObjectOfType<NextGroup>().showNextGroup();
	//Note: the Start function will automatically be called by Unity as soon as the game starts.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public GameObject getNextGroupToShow() {
		return nextGroup;
	}

	private int getRandomGroup() {
		return Random.Range(0, groups.Length);
	}

	private GameObject getGroupByIndex(int index) {
		return groups[index];
	}

	public void spawnNext() {
		//Note: transform.position is the Spawner's position, Quaternion.identity is the default rotation.
		int i = Random.Range (0, groups.Length);
		if (nextGroup == null) {
			Instantiate (groups [i], transform.position, Quaternion.identity);
		} else {
			Instantiate (nextGroup, transform.position, Quaternion.identity);
		}

		nextGroup = groups[i];
	}
}
