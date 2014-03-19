using UnityEngine;
using System.Collections;

public class LogoController : MonoBehaviour {

	bool _showMenu;
	LogoLWF _logolwf;
	GameObject _girlfriend;
	GameObject _boyfriend;
	// Use this for initialization
	void Start () {
		_logolwf = FindObjectOfType<LogoLWF> ();

		GameObject _headGirl = Instantiate (Resources.Load ("Prefabs/couples/Girl/Heads/" + PlayerPrefs.GetString ("currentHeadGirl","0").Replace ("(Clone)", "")),Camera.main.ViewportToWorldPoint (new Vector3 (0.43f, 0.88f)),Quaternion.identity) as GameObject;
		GameObject _bodyGirl = Instantiate (Resources.Load ("Prefabs/couples/Girl/Bodies/" + PlayerPrefs.GetString ("currentBodyGirl","0").Replace ("(Clone)", "")), Camera.main.ViewportToWorldPoint (new Vector3 (0.4f, 0.7f,+1)),Quaternion.identity) as GameObject;
		_girlfriend = new GameObject ("girl");
		_headGirl.transform.parent = _girlfriend.transform;
		_bodyGirl.transform.parent = _girlfriend.transform;
		_girlfriend.transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (1.3f, 0.3f,+15));
		_girlfriend.transform.localScale = new Vector3(1.5f,1.5f,1f);


		GameObject _headBoy = Instantiate (Resources.Load ("Prefabs/couples/Boy/Heads/" + PlayerPrefs.GetString ("currentHeadBoy","0").Replace ("(Clone)", "")),Camera.main.ViewportToWorldPoint (new Vector3 (0.43f, 0.88f)),Quaternion.identity) as GameObject;
		GameObject _bodyBoy = Instantiate (Resources.Load ("Prefabs/couples/Boy/Bodies/" + PlayerPrefs.GetString ("currentBodyBoy","0").Replace ("(Clone)", "")), Camera.main.ViewportToWorldPoint (new Vector3 (0.4f, 0.7f,+1)),Quaternion.identity) as GameObject;
		_boyfriend = new GameObject ("Boy");
		_headBoy.transform.parent = _boyfriend.transform;
		_bodyBoy.transform.parent = _boyfriend.transform;
		_boyfriend.transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (1.6f, 0.3f,+20));
		_boyfriend.transform.localScale = new Vector3(1.5f,1.5f,1f);
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
		StartCoroutine (EnterGirl ());
		StartCoroutine (EnterBoy ());
	}

	IEnumerator EnterGirl()
	{
		while (_girlfriend.transform.position != Camera.main.ViewportToWorldPoint(new Vector3(0.8f, 0.3f,+15)))
		{
			_girlfriend.transform.position = Vector3.MoveTowards (_girlfriend.transform.position, Camera.main.ViewportToWorldPoint (new Vector3 (0.8f, 0.3f, +15)), 10f);
			yield return null;
		}
	}

	IEnumerator EnterBoy()
	{
		while (_girlfriend.transform.position != Camera.main.ViewportToWorldPoint(new Vector3(0.6f, 0.3f,+15)))
		{
			_boyfriend.transform.position = Vector3.MoveTowards (_boyfriend.transform.position, Camera.main.ViewportToWorldPoint (new Vector3 (0.6f, 0.3f, +15)), 15f);		
			yield return null;
		}
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
