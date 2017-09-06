﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Group : MonoBehaviour {
	// Time since last gravity tick
	float lastFall = 0;

	// Use this for initialization
	void Start() {
		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
//			Debug.Log("GAME OVER");
//			FindObjectOfType<PauseScript>().setGameover(true);
			Destroy(gameObject);
			SceneManager.LoadScene("GameoverScene");
		}
	}
	
	// Update is called once per frame
	void Update() {
		if ((int)transform.position.x >= 12 && (int)transform.position.y >= 0)
			return;

		// Move Left
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			// Modify position
			transform.position += new Vector3(-1, 0, 0);

			// See if valid
			if (isValidGridPos())
				// Its valid. Update grid.
				updateGrid();
			else
				// Its not valid. revert.
				transform.position += new Vector3(1, 0, 0);
		} // Move Right
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			// Modify position
			transform.position += new Vector3(1, 0, 0);

			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.position += new Vector3(-1, 0, 0);
		}
		// Rotate
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0, 0, -90);

			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.Rotate(0, 0, 90);
		}
		// Move Downwards and Fall
		else if ((Input.GetKeyDown(KeyCode.DownArrow) ||
			Time.time - lastFall >= 1) || (Input.GetKey(KeyCode.DownArrow) &&
			Time.time - lastFall >= 0.2)) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);

			// See if valid
			if (isValidGridPos()) {
				// It's valid. Update grid.
				updateGrid();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(0, 1, 0);

				// Clear filled horizontal lines
				int lines =	Grid.deleteFullRows();
				Score.addPoints(lines);

				// Spawn next Group
				FindObjectOfType<Spawner>().spawnNext();
				FindObjectOfType<NextGroup>().showNextGroup();

				// Disable script
				enabled = false;
			}
			if ((Input.GetKey(KeyCode.DownArrow) &&
			Time.time - lastFall >= 0.2)) {
			}
			else {
			lastFall = Time.time;
			}
		}
	}


	bool isValidGridPos() {
		//Checking if the group is in the NextGroupPanel
		if ((int)transform.position.x >= 12 && (int)transform.position.y >= 0)
			return true;

		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);

			// Not inside Border?
			if (!Grid.insideBorder(v))
				return false;

			// Block in grid cell (and not part of same group)?
			if (Grid.grid[(int)v.x, (int)v.y] != null &&
				Grid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}

		return true;
	}

	void updateGrid() {
		// Remove old children from grid
		for (int y = 0; y < Grid.h; ++y)
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grid[x, y] != null)
				if (Grid.grid[x, y].parent == transform)
					Grid.grid[x, y] = null;

		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x, (int)v.y] = child;
		}        
	}
	public Transform[,] getGrid() {
		return Grid.grid;
	}
}