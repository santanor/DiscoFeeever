using UnityEngine;
using System.Collections;
using System;
 
[Serializable]
public class ScoreEntry{

	public int Score;
	public string Name;
	public DateTime dateTime;

	public ScoreEntry(int score, string name)
	{
		this.Score = score;
		this.Name = name;
		dateTime = DateTime.Today;
	}
}
