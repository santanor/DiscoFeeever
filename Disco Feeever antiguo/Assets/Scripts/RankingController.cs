using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class RankingController : MonoBehaviour {

	IList<ScoreEntry> list;

	// Use this for initialization
	void Start () {
		var data = PlayerPrefs.GetString("highScores");
		if(data == null) list = new List<ScoreEntry>();
		
		var formatter = new BinaryFormatter();
		var stream = new MemoryStream(Convert.FromBase64String(data));
		list = ((List<ScoreEntry>)formatter.Deserialize(stream));
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Box(new Rect( ScreenExt.Width(30),ScreenExt.Height(30), ScreenExt.Width(50), ScreenExt.Height(50)), "Ranking");
		GUILayout.BeginArea (new Rect (ScreenExt.Width(35),ScreenExt.Height(35), ScreenExt.Width (50f), ScreenExt.Height (50f)));
		for(int i = 0; i < list.Count;i++)
			GUI.Label(new Rect(ScreenExt.Width (0),  ScreenExt.Height (10*i),ScreenExt.Width (50),  ScreenExt.Height (50)),list[i].Name.ToString()+"\t\t"+list[i].Score.ToString()+"\t\t"+list[i].dateTime.ToString());
		GUILayout.EndArea();
	}
}
