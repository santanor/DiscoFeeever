using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	public GameObject Garrulo {get; set;}
	public GameObject Friki {get; set;}
	public GameObject Torrente {get; set;}
	public GameObject Chulo {get; set;}
	public int Level {get; set;}
	JSONObject jObject;


	// Use this for initialization
	void Start () {
		System.IO.StreamReader reader = new System.IO.StreamReader(Application.dataPath+"/levels.json");
		jObject = new JSONObject(reader.ReadToEnd());
		//int count = jObject["levels"]["level"]["implements"].list.Count;
		//print (count);
		foreach(var obj in jObject["levels"]["level"][Level]["implements"]["implement"][0]["enemy"].list)
			print (obj);

	}
	
	// Update is called once per frame
	void Update () {

	}
}

public class Moscon
{
	public GameObject moscon {get;set;}
	public int timer {get;set;}

	public Moscon(string Moscon,int timmer)
	{
	}
}
