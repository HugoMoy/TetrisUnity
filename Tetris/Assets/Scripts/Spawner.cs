using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		//transform.position is the Spawner's position, Quaternion.identity is the default rotation.
		int i = Random.Range (0, groups.Length);
		
		if (nextGroup == null) {
			Instantiate (groups [i], transform.position, Quaternion.identity);
			i = Random.Range (0, groups.Length);
		} else {

			//Debug.Log("Position = "+transform.position);
			GameObject a = Instantiate (nextGroup, transform.position, Quaternion.identity);
			Transform b0 = a.transform.GetChild(0);
			Transform b1 = a.transform.GetChild(1);
			Transform b2 = a.transform.GetChild(2);
			Transform b3 = a.transform.GetChild(3);
			// Debug.Log(b0.position);
			// Debug.Log(b1.position);
			// Debug.Log(b2.position);
			// Debug.Log(b3.position);

			Transform[,] alpha =FindObjectOfType<Group>().getGrid();
			if(alpha[(int)b0.position.x, (int)b0.position.y] != null ){
				SceneManager.LoadScene("GameoverScene");
				Debug.Log("GameOver");
			}
			if(alpha[(int)b1.position.x, (int)b1.position.y] != null ){
				SceneManager.LoadScene("GameoverScene");
				Debug.Log("GameOver");
			}
			if(alpha[(int)b2.position.x, (int)b2.position.y] != null ){
				SceneManager.LoadScene("GameoverScene");
				Debug.Log("GameOver");
			}
			if(alpha[(int)b3.position.x, (int)b3.position.y] != null ){
				SceneManager.LoadScene("GameoverScene");
				Debug.Log("GameOver");
			}
			
		}

		nextGroup = groups[i];
	}
}
