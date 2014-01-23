using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Girlfriend girlfriend;
	private bool gameOver;
	private GameObject Text;
	public int NumberOfMoscones {get; set;}
	// Use this for initialization
	void Start () {
		NumberOfMoscones = 0;
		Text= GameObject.Find("Text");
		Text.GetComponent<GUIText>().text = "Level "+PlayerPrefs.GetInt("Level");
		Invoke("Cosa",3f);
	}

	void Cosa()
	{
		this.Text.guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(girlfriend.Life <= 0 && !gameOver)
		{
			Time.timeScale = 0;
			Text.guiText.text = "Game Over Bitch";
			gameOver  =true;
			PlayerPrefs.SetInt("Level",0);
		}
		else if(NumberOfMoscones == 0)
		{
			PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnGUI()
	{
		if(gameOver)
			if (GUI.Button(new Rect(300, 200,70, 70), "Reset"))
			{
			Time.timeScale = 1;
				Application.LoadLevel("Main Menu");
			}
	}


}
