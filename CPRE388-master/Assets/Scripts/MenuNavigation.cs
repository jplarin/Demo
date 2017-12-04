using UnityEngine;
using System.Collections;

public class MenuNavigation : MonoBehaviour 
{

	public void MainMenu()
	{
		Application.LoadLevel("menu");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Play()
	{
		Application.LoadLevel("main");
	}

	public void HighScores()
	{
		Application.LoadLevel("score");

	}
	public void Settings()
	{
		Application.LoadLevel("setting");

	}
		
}