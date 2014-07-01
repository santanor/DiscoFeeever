using UnityEngine;
using System.Collections;


public class ShowBacground : MonoBehaviour {

	GameObject _scenario;
	Vector3 _scenarioPosition;

	// Use this for initialization
	void Start () 
	{
		_scenarioPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 1f,100));
		_scenario = Instantiate(Resources.Load("Prefabs/Scenarios/"+PlayerPrefs.GetString("currentScenario").Replace("(Clone)","")), _scenarioPosition, Quaternion.identity) as GameObject;	
		_scenario.transform.localScale = new Vector3(1.67f,1.67f,0);
	}
}
