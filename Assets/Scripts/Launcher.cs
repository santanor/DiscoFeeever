using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour {

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
			CreateMoscon(obj[0].ToString().Replace("\"",""),obj[1].ToString().Replace("\"",""), obj[2].ToString().Replace("\"",""));

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

	private void CreateMoscon(string sprite, string time, string street)
	{
		GameObject moscon = (GameObject)Instantiate(Resources.Load("Prefabs/Moscones/"+sprite));
		Vector3 position = Camera.main.ViewportToWorldPoint( new Vector3(1f, (0.2f + (0.2f)*int.Parse(street)), 1f));
		moscon.transform.position = position;
		moscon.GetComponent<MosconAbstract>().SetTimer(int.Parse(time));
		moscones.Add(moscon.GetComponent<MosconAbstract>());
	}
}

