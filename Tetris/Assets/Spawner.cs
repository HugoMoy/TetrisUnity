using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Groups
	public GameObject[] groups;

	// Use this for initialization
	void Start () {
		// Spawn initial Group
		spawnNext();

	//Note: the Start function will automatically be called by Unity as soon as the game starts.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnNext() {
		// Random Index
		int i = Random.Range(0, groups.Length);

		// Spawn Group at current Position
		Instantiate(groups[i], transform.position, Quaternion.identity);

		//Note: transform.position is the Spawner's position, Quaternion.identity is the default rotation.
	}
}
