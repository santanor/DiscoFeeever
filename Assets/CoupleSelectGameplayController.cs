using UnityEngine;
using System.Collections;
using System.Linq;

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
		_currentBody = Instantiate(_bodies [0])  as GameObject;
		_currentHead = Instantiate( _heads [0]) as GameObject;
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
			StartCoroutine(ChangeHead(_currentHeadIndex));

		}
		if (GUI.Button (new Rect (ScreenExt.Width (65), ScreenExt.Height (25), ScreenExt.Width (10), ScreenExt.Height (10)), "Next"))
		{
			_currentHeadIndex +=1;
			if(_currentHeadIndex > _heads.Length -1) _currentHeadIndex = 0;
			StartCoroutine(ChangeHead(_currentHeadIndex));
		}

		//Body
		if (GUI.Button (new Rect (ScreenExt.Width (25), ScreenExt.Height (55), ScreenExt.Width (10), ScreenExt.Height (10)), "Prev")) 
		{
			_currentBodyIndex -=1;
			if(_currentBodyIndex <0) _currentBodyIndex = _bodies.Length -1;
			StartCoroutine(ChangeBody(_currentBodyIndex));
		}
		if (GUI.Button (new Rect (ScreenExt.Width (65), ScreenExt.Height (55), ScreenExt.Width (10), ScreenExt.Height (10)), "Next"))
		{
			_currentBodyIndex +=1;
			if(_currentBodyIndex > _bodies.Length -1) _currentBodyIndex = 0;
			StartCoroutine(ChangeBody(_currentBodyIndex));
		}

		//Avanti
		if (GUI.Button (new Rect (ScreenExt.Width (85), ScreenExt.Height (85), ScreenExt.Width (10), ScreenExt.Height (10)), "Avanti")) 
		{
			GameObject couple = new GameObject("couple");
			couple.transform.position = _headPosition;
			_currentBody.transform.parent = couple.transform;
			_currentHead.transform.parent = couple.transform;
			UnityEditor.PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/Couples/couple.prefab",couple);
			Application.LoadLevel("levels");
		}
	}

	IEnumerator ChangeBody(int index)
	{
		float alpha = 1f;
		while (alpha > 0) 
		{
			alpha -= 0.1f;
			_currentBody.GetComponent<ShowCouple>().SetAlpha(alpha);
			yield return null;
		}
		Destroy (_currentBody);
		_currentBody = Instantiate (_bodies [index], _bodyPosition, Quaternion.identity) as GameObject;
		
		while (alpha < 1) 
		{
			alpha += 0.1f;
			_currentBody.GetComponent<ShowCouple>().SetAlpha(alpha);
			yield return null;
		}
	}

	IEnumerator ChangeHead(int index)
	{ 
		float alpha = 1f;
		while (alpha > 0) 
		{
			alpha -= 0.1f;
			_currentHead.GetComponentsInChildren<ShowCouple>().ToList().ForEach((x) => x.SetAlpha(alpha));
			yield return null;
		}
		Destroy (_currentHead);
		_currentHead = Instantiate (_heads [index], _headPosition, Quaternion.identity) as GameObject;

		while (alpha < 1) 
		{
			alpha += 0.1f;
			_currentHead.GetComponentsInChildren<ShowCouple>().ToList().ForEach((x) => x.SetAlpha(alpha));
			yield return null;
		}
	}


}
