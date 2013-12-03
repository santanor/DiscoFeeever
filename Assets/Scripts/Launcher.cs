using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour {

	public Garrulo Garrulo;
	public Friki Friki;
	public Torrente Torrente;
	public Chulo Chulo;
	public int Level;
	JSONObject jObject;
    List<MosconAbstract> moscones;
	float timer;


	// Use this for initialization
	void Start () {
		timer = 0;
		moscones = new List<MosconAbstract>();
		System.IO.StreamReader reader = new System.IO.StreamReader(Application.dataPath+"/levels.json");
		jObject = new JSONObject(reader.ReadToEnd());
		foreach(var obj in jObject["levels"]["level"][Level]["implements"]["implement"][0]["enemy"].list)
			CreateMoscon(obj[0].ToString().Replace("\"",""),obj[1].ToString().Replace("\"",""));

	}

	void Update () {
		timer += Time.deltaTime;
		if(moscones.Count > 0)
		{
			if(moscones[0].GetTimer() < timer)
			{
				moscones[0].Launch();
				moscones.RemoveAt(0);
			}
		}
		//else
			//Time.timeScale = 0;
	}

	private void CreateMoscon(string sprite, string time)
	{
        MosconAbstract gObject = null;
		switch(sprite)
		{
			case "garrulo":
				gObject = Garrulo;
			break;
			case "chulo":
				gObject = Chulo;
			break;
			case "torrente":
				gObject = Torrente;
			break;
			case "friki":
				gObject = Friki;
			break;
		}

		MosconAbstract clone = (MosconAbstract)Instantiate((Object)gObject);
		clone.SetTimer(int.Parse(time));

		moscones.Add(clone);
	}
}

