using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public int Score {get; set;}

	// Use this for initialization
	void Start () {
		this.Score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.guiText.text = Score.ToString();
	}
}
