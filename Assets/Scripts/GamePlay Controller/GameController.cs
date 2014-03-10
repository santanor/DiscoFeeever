using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Girlfriend girlfriend;
	bool _gameOver;
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
	}

	public void PauseGameBeforeShop()
	{
		FindObjectOfType<Launcher> ().enabled = false;
		FindObjectOfType<NormalWeaponChooser> ().enabled = false;
		FindObjectOfType<SpecialWeaponChooser> ().enabled = false;
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
		if (girlfriend.Life <= 0 && !_gameOver) {
						Time.timeScale = 0;
						_text.guiText.text = "Game Over Bitch";
						_gameOver = true;
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
		if(_gameOver)
			if (GUI.Button(new Rect(300, 200,70, 70), "Reset"))
			{
			Time.timeScale = 1;
				Application.LoadLevel("Main Menu");
			}
	}


}
