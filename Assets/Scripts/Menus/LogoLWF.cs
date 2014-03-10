using UnityEngine;
using System.Collections;
using LWF;
using System;

[ExecuteInEditMode]
public class LogoLWF : LWFObject {

	float currentScale;
	// Use this for initialization
	void Start () {
		Vector3 position = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 1f, 0f));
		this.transform.position = position;

		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		Load(lwfName, dir);
	}

	public void StartTopLeft()
	{
		StartCoroutine (TopLeft ());
	}


	IEnumerator TopLeft()
	{
		currentScale = 1f;
		for (int i = 0; i < 25; i++) 
		{
			currentScale -= 0.0015f;
			Scale(currentScale,currentScale);
			yield return null;
		}
		yield return null;
	}

}
