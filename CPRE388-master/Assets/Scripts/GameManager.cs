﻿using System;
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int lives = 3;

	public enum GameState { Init, Game, Dead, Scores }
	public static GameState gameState;

	private GameObject pacman;
	private GameObject blinky;
	private GameObject pinky;
	private GameObject inky;
	private GameObject clyde;
	private UINavigation gui;

	public static bool scared;
	static public int score;

	public float scareLength;
	private float _timeToCalm;

	public float SpeedPerLevel;

	private static GameManager _instance;

	public static GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameManager>();
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			if(this != _instance)   
				Destroy(this.gameObject);
		}

		AssignGhosts();
	}

	void Start () 
	{
		gameState = GameState.Init;
	}
		

	private void ResetVariables()
	{
		_timeToCalm = 0.0f;
		scared = false;
	}

	void Update () 
	{
		if(scared && _timeToCalm <= Time.time)
			CalmGhosts();

	}

	public void ResetScene()
	{
		CalmGhosts();

		pacman.transform.position = new Vector3(15f, 11f, 0f);
		blinky.transform.position = new Vector3(15f, 20f, 0f);
		pinky.transform.position = new Vector3(14.5f, 17f, 0f);
		inky.transform.position = new Vector3(16.5f, 17f, 0f);
		clyde.transform.position = new Vector3(12.5f, 17f, 0f);

		//pacman.GetComponent<PlayerController>().ResetDestination();
		blinky.GetComponent<GhostMove>().InitializeGhost();
		pinky.GetComponent<GhostMove>().InitializeGhost();
		inky.GetComponent<GhostMove>().InitializeGhost();
		clyde.GetComponent<GhostMove>().InitializeGhost();

		gameState = GameState.Init;  

	}

	public void ToggleScare()
	{
		if(!scared)	ScareGhosts();
		else 		CalmGhosts();
	}

	public void ScareGhosts()
	{
		scared = true;
		_timeToCalm = Time.time + scareLength;

		Debug.Log("Ghosts Scared");
	}

	public void CalmGhosts()
	{
		scared = false;
	
	}

	void AssignGhosts()
	{
		clyde = GameObject.Find("clyde");
		pinky = GameObject.Find("pinky");
		inky = GameObject.Find("inky");
		blinky = GameObject.Find("blinky");
		pacman = GameObject.Find("pacman");

		if (clyde == null || pinky == null || inky == null || blinky == null) Debug.Log("One of ghosts are NULL");
		if (pacman == null) Debug.Log("Pacman is NULL");

		gui = GameObject.FindObjectOfType<UINavigation>();

		if(gui == null) Debug.Log("GUI Handle Null!");

	}

	public void LoseLife()
	{
		lives--;
		gameState = GameState.Dead;

	}

	public static void DestroySelf()
	{

		score = 0;
		lives = 3;
		Destroy(GameObject.Find("Game Manager"));
	}
}

