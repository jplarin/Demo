using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public static int highscore;
	Text text;

	public class Score
	{
		public string name { get; set; }
		public int score { get; set; }

		public Score(string n, int s)
		{
			name = n;
			score = s;
		}

		public Score(string n, string s)
		{
			name = n;
			score = Int32.Parse(s);
		}
	}

	void start()
	{
		text = GetComponent<Text> ();
		score = 0;

		highscore = PlayerPrefs.GetInt ("highscore", highscore);
		text.text = highscore.ToString();
	}

	void update()
	{
		if (score > highscore) {
			highscore = score;
			text.text = "" + score;

			PlayerPrefs.SetInt ("highscore", highscore);
		}

	}

	public static void addPoints(int points)
	{
		score += points;
	}

	void onDestory()
	{
		PlayerPrefs.SetInt ("highscore", highscore);
		PlayerPrefs.Save();
	}

}
