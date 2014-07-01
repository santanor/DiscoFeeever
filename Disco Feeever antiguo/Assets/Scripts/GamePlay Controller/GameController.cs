using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

	public Girlfriend girlfriend;
	public bool _gameOver;
	GameObject _text;
	public int NumberOfMoscones {get; set;}
	bool _nextLevel;

	void awake()
	{
		PauseGameBeforeShop ();
	}
	void Start()
	{
		PauseGameBeforeShop ();
	}

	public void StartGameAfterShop()
	{
		_text= GameObject.Find("Text");
		FindObjectOfType<Launcher> ().enabled = true;
		FindObjectOfType<NormalWeaponChooser> ().enabled = true;
		FindObjectOfType<NormalWeaponChooser> ()._Start ();
		FindObjectOfType<SpecialWeaponChooser> ().enabled = true;
		FindObjectOfType<SpecialWeaponChooser> ()._Start ();
		FindObjectOfType<ScoreController> ().enabled = true;
	}

	public void PauseGameBeforeShop()
	{
		FindObjectOfType<Launcher> ().enabled = false;
		FindObjectOfType<NormalWeaponChooser> ().enabled = false;
		FindObjectOfType<SpecialWeaponChooser> ().enabled = false;
		FindObjectOfType<ScoreController> ().enabled = false;
	}

	public void SetHour(string hour)
	{
		_text.GetComponent<GUIText>().text = hour;
		Invoke("DeleteText",3f);
	}

	private void DeleteText()
	{
		_text.GetComponent<GUIText>().text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (girlfriend.Life <= 0 && !_gameOver) 
		{
			Time.timeScale = 0;
			_gameOver = true;
			FindObjectOfType<ScoreController>().StartMoveScoreMiddle();
			FindObjectOfType<SpecialWeaponChooser> ().ReincorporateWeapons ();
			PlayerPrefs.SetInt ("Level", 0);
		} else if (NumberOfMoscones == 0 && !_nextLevel) 
			PlayerPrefs.SetInt ("Level", PlayerPrefs.GetInt ("Level") + 1);
		 else if (_nextLevel) {
			Application.LoadLevel (Application.loadedLevel);
			FindObjectOfType<SpecialWeaponChooser>().ReincorporateWeapons();
		}
	}

	void OnGUI()
	{
		if (_gameOver) 
		{
			int score = FindObjectOfType<ScoreController>().Score;
			IList<ScoreEntry> list;
			var data = PlayerPrefs.GetString("highScores");
			if(data == null) list = new List<ScoreEntry>();

			var formatter = new BinaryFormatter();
			var stream = new MemoryStream(Convert.FromBase64String(data));
			list = ((List<ScoreEntry>)formatter.Deserialize(stream));
		    list.Add(new ScoreEntry(score, PlayerPrefs.GetString("usarname","Username")));
			list = list.OrderBy(o=> o.Score).Take(10).ToList();

			stream.Dispose();
			formatter.Serialize(stream, list);
			PlayerPrefs.SetString("highScores", Convert.ToBase64String(stream.GetBuffer()));


			if (GUI.Button (new Rect (ScreenExt.Width (30), ScreenExt.Height (70), ScreenExt.Width (10), ScreenExt.Height (10)), "Reset")) {
					Time.timeScale = 1;
					Application.LoadLevel ("SelectGameplay");
			}

			if (GUI.Button (new Rect (ScreenExt.Width (50), ScreenExt.Height (70), ScreenExt.Width (10), ScreenExt.Height (10)), "Exit")) {
					Time.timeScale = 1;
					Application.LoadLevel ("Ranking");
			}
		}
	}


}
