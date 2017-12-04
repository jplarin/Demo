using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	private GameObject blinky;
	private GameObject pinky;
	private GameObject inky;
	private GameObject clyde;
	public static int difficulty = 0;
	private UINavigation gui;
	private GameManager gm;
	public Canvas CanvasDifficulty;
	private bool easy;
	private bool medium;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void AssignGhosts()
	{
		// find and assign ghosts
		clyde = GameObject.Find("clyde");
		pinky = GameObject.Find("pinky");
		inky = GameObject.Find("inky");
		blinky = GameObject.Find("blinky");

		if (clyde == null || pinky == null || inky == null || blinky == null) Debug.Log("One of ghosts are NULL");

		gui = GameObject.FindObjectOfType<UINavigation>();

		if(gui == null) Debug.Log("GUI Handle Null!");

	}

	public void ToggleDifficuly()
	{
		CanvasDifficulty.enabled = true;
		if (easy)
			AssignGhosts ();
		else if (medium) {
			
			clyde.GetComponent<GhostMove> ().speed += 6;
			blinky.GetComponent<GhostMove> ().speed += 6;
			pinky.GetComponent<GhostMove> ().speed += 6;
			inky.GetComponent<GhostMove> ().speed += 6;
		}
					
		else
		{
			clyde.GetComponent<GhostMove>().speed += 8;
			blinky.GetComponent<GhostMove>().speed += 8;
			pinky.GetComponent<GhostMove>().speed += 8;
			inky.GetComponent<GhostMove>().speed += 8;
		}	

	}
}