using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour {

	public GameObject Garrulo;
	public GameObject Friki;
	public GameObject Torrente;
	public GameObject Chulo;
	public int Level;
	JSONObject jObject;
	List<Moscon> moscones;
	float timer;


	// Use this for initialization
	void Start () {
		timer = 0;
		moscones = new List<Moscon>();
		System.IO.StreamReader reader = new System.IO.StreamReader(Application.dataPath+"/levels.json");
		jObject = new JSONObject(reader.ReadToEnd());
		foreach(var obj in jObject["levels"]["level"][Level]["implements"]["implement"][0]["enemy"].list)
			CreateMoscon(obj[0].ToString().Replace("\"",""),obj[1].ToString().Replace("\"",""));

	}

	void Update () {
		timer += Time.deltaTime;
		if(moscones.Count > 0)
		{
			if(moscones[0].timer < timer)
			{
				GameObject clonedGuy = (GameObject)Instantiate(moscones[0].moscon,moscones[0].moscon.transform.position, Quaternion.identity);
				clonedGuy.transform.rigidbody2D.velocity = Vector3.left*50;
				moscones.RemoveAt(0);
			}
		}
		//else
			//Time.timeScale = 0;
	}

	private void CreateMoscon(string sprite, string time)
	{
		GameObject gObject = null;
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

		moscones.Add(new Moscon(gObject, int.Parse(time)));
	}
}

public class Moscon
{
	public GameObject moscon {get;set;}
	public int timer {get;set;}

	public Moscon(GameObject Moscon,int timer)
	{
		this.moscon = Moscon;
		this.timer = timer;
	}
}
