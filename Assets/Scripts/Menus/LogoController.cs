using UnityEngine;
using System.Collections;

public class LogoController : MonoBehaviour {

	bool _showMenu;
	LogoLWF _logolwf;
	// Use this for initialization
	void Start () {
		_logolwf = FindObjectOfType<LogoLWF> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetTouch (0).phase == TouchPhase.Began && !_showMenu) 
		{
			ManagePhaseBegan();
			_showMenu = true;
		}
	}

	void ManagePhaseBegan()
	{
		_logolwf.StartTopLeft ();
	}

	void OnGUI()
	{
		if (_showMenu) 
		{
			if(GUI.Button(new Rect(ScreenExt.Width(5), ScreenExt.Height(85), ScreenExt.Width(10), ScreenExt.Height(10)),"Play"))
				Application.LoadLevel("SelectGameplay");
			if(GUI.Button(new Rect(ScreenExt.Width(20), ScreenExt.Height(85), ScreenExt.Width(10), ScreenExt.Height(10)),"Store"))
				;
			if(GUI.Button(new Rect(ScreenExt.Width(35), ScreenExt.Height(85), ScreenExt.Width(10), ScreenExt.Height(10)),"Ranking"))
				;
		}
	}
}
