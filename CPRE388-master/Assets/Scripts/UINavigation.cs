using System;
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour {


	private bool paused;
	private bool quit;
	public Canvas PauseCanvas;


	public float initialDelay;

	public Button MenuButton;


	void Start () 
	{
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameManager.gameState == GameManager.GameState.Scores)
				Menu();

			else
			{
				if(quit == true)
					ToggleQuit();
				else
					TogglePause();
			}
		}
	}
		
	public void getScoresMenu()
	{
		Time.timeScale = 0f;		
		GameManager.gameState = GameManager.GameState.Scores;
		MenuButton.enabled = false;
	}
		

	public void TogglePause()
	{		
		if(paused)
		{
			Time.timeScale = 1;
			PauseCanvas.enabled = false;
			paused = false;
			MenuButton.enabled = true;
		}

		else
		{
			PauseCanvas.enabled = true;
			Time.timeScale = 0.0f;
			paused = true;
			MenuButton.enabled = false;
		}
			
		Debug.Log("PauseCanvas enabled: " + PauseCanvas.enabled);
	}

	public void ToggleQuit()
	{
		if(quit)
		{
			PauseCanvas.enabled = true;
			quit = false;
		}

		else
		{
			PauseCanvas.enabled = false;
			quit = true;
		}
	}

	public void Menu()
	{
		Application.LoadLevel("menu");
		Time.timeScale = 1.0f;

		GameManager.DestroySelf();
	}

	public void LoadLevel()
	{
		Application.LoadLevel("main");
	}
		
}
