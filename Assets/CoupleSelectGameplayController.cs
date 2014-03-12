using UnityEngine;
using System.Collections;

public class CoupleSelectGameplayController : MonoBehaviour {

	Object[] _heads;
	Object[] _bodies;
	GameObject _currentHead;
	GameObject _currentBody;
	Vector3 _headPosition;
	Vector3 _bodyPosition;
	float _deltaPosition;
	int _currentHeadIndex; 
	int _currentBodyIndex;

	void Start()
	{
		_heads = Resources.LoadAll ("Prefabs/Couples/Heads");
		_bodies = Resources.LoadAll ("Prefabs/Couples/Bodies");
		_currentBody = Instantiate(_bodies [1])  as GameObject;
		_currentHead = Instantiate( _heads [1]) as GameObject;
		_headPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0.43f, 0.88f));
		_bodyPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0.4f, 0.7f,+1));
		_currentBody.transform.position = _bodyPosition;
		_currentHead.transform.position = _headPosition;
	}
	// Use this for initialization
	public void Restart () {
	
	}


	void OnGUI()
	{
		//Head
		if (GUI.Button (new Rect (ScreenExt.Width (25), ScreenExt.Height (25), ScreenExt.Width (10), ScreenExt.Height (10)), "Prev")) 
		{
			 _currentHeadIndex -=1;
			if(_currentHeadIndex < 0) _currentHeadIndex = _heads.Length -1;


		}
		if (GUI.Button (new Rect (ScreenExt.Width (65), ScreenExt.Height (25), ScreenExt.Width (10), ScreenExt.Height (10)), "Next"))
		{
			_currentHeadIndex +=1;
			if(_currentHeadIndex > _heads.Length -1) _currentHeadIndex = 0;
		}

		//Body
		if (GUI.Button (new Rect (ScreenExt.Width (25), ScreenExt.Height (55), ScreenExt.Width (10), ScreenExt.Height (10)), "Prev"))
						;
		if (GUI.Button (new Rect (ScreenExt.Width (65), ScreenExt.Height (55), ScreenExt.Width (10), ScreenExt.Height (10)), "Next"))
						;
	}

	IEnumerator SwapeRight(Vector3 position,  GameObject obj)
	{ 
		yield return null;
	}

}
