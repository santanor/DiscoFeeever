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

	public void StartMoveScoreMiddle()
	{
		StartCoroutine(MoveScoreMiddle());
	}

	IEnumerator MoveScoreMiddle()
	{
		Vector3 position = new Vector3(0.5f,0.3f,0);
		this.transform.position = position;
		this.guiText.pixelOffset = new Vector2(0,0);
		this.guiText.fontSize = 200;
		this.guiText.alignment = TextAlignment.Center;
		this.guiText.anchor = TextAnchor.LowerCenter;

		while(true)
		{
			this.guiText.color = Color.white;
			yield return new WaitForSeconds(0.2f);
			this.guiText.color =Color.black;
			yield return new WaitForSeconds(1f);
		}

		yield return null;
	}
}
