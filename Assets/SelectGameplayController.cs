using UnityEngine;
using System.Collections;

public class SelectGameplayController : MonoBehaviour {
	
	Vector3 _scenarioPosition;
	GameObject _currentScenario;
	int _currentScenarioIndex;
	Object[] _scenarios;
	float _deltaPosition;
	// Use this for initialization
	void Start () {
		_scenarios = Resources.LoadAll("Prefabs/Scenarios/");
		_scenarioPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0.2f, 0.8f));
		_currentScenario = Instantiate (_scenarios [0], _scenarioPosition, Quaternion.identity)as GameObject;
		_currentScenarioIndex = 0;
	}

	void Update()
	{
		foreach (Touch touch in Input.touches) 
		{
			TouchPhase phase = touch.phase;
			switch(phase)
			{
			case TouchPhase.Began:
				ManagePhaseBegan(touch);
				break;

			case TouchPhase.Ended:
				ManagePhaseEnd(touch);
				break;
			}
		}
	}

	void ManagePhaseBegan(Touch touch)
	{
		_deltaPosition = touch.position.x;
	}

	void ManagePhaseEnd(Touch touch)
	{
		if (_deltaPosition > touch.position.x)
		{
			_currentScenarioIndex -= 1;
			if (_currentScenarioIndex < 0)	_currentScenarioIndex = _scenarios.Length - 1;
			StartCoroutine (SwapeLeft (_currentScenarioIndex));
		} 
		else if (_deltaPosition < touch.position.x) 
		{
			_currentScenarioIndex += 1;
			if(_currentScenarioIndex > _scenarios.Length -1) _currentScenarioIndex = 0;
			StartCoroutine(SwapeRight(_currentScenarioIndex));
		}
	}


	IEnumerator SwapeLeft(int index)
	{
		float movePerFrame = 5f;
		Vector3 position = _scenarioPosition;
		position.x -= _currentScenario.GetComponent<ShowScenario> ().lwf.width;

		while (_currentScenario.transform.position != position)
		{
			_currentScenario.transform.position = Vector3.MoveTowards (_currentScenario.transform.position, position, 30f);
			yield return null;
		}
		Destroy (_currentScenario);

		Vector3 enterPosition = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0.8f));
		_currentScenario = Instantiate (_scenarios [index], enterPosition, Quaternion.identity) as GameObject;

		while (_currentScenario.transform.position != _scenarioPosition)
		{
			_currentScenario.transform.position = Vector3.MoveTowards (_currentScenario.transform.position, _scenarioPosition, 30f);
			yield return null;
		}

	}

	IEnumerator SwapeRight (int index)
	{
		float movePerFrame = 5f;
		Vector3 position = _scenarioPosition;
		position.x += _currentScenario.GetComponent<ShowScenario> ().lwf.width;
		
		while (_currentScenario.transform.position != position)
		{
			_currentScenario.transform.position = Vector3.MoveTowards (_currentScenario.transform.position, position, 30f);
			yield return null;
		}
		Destroy (_currentScenario);
		
		Vector3 enterPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0.8f));
		enterPosition.x -= _currentScenario.GetComponent<ShowScenario> ().lwf.width/2;
		_currentScenario = Instantiate (_scenarios [index], enterPosition, Quaternion.identity) as GameObject;
		
		while (_currentScenario.transform.position != _scenarioPosition)
		{
			_currentScenario.transform.position = Vector3.MoveTowards (_currentScenario.transform.position, _scenarioPosition, 30f);
			yield return null;
		}
	}
}
