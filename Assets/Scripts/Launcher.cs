using UnityEngine;
using System.Collections.Generic;

public class Launcher : MonoBehaviour {

	int Level;
	JSONObject jObject;
    List<MosconAbstract> moscones;
	float timer;
	IDictionary<string, GameObject> mosconesObj;
	public string hour;


	// Use this for initialization
	void Start () {
		timer = 0;
		PlayerPrefs.SetInt ("Level", 0);
		mosconesObj = new Dictionary<string, GameObject> ();
		foreach (GameObject o in Resources.LoadAll("Prefabs/Moscones/"))
				mosconesObj.Add (o.name, o);

		Level = PlayerPrefs.GetInt("Level",0);
		moscones = new List<MosconAbstract>();
		jObject = new JSONObject(Resources.Load("levels").ToString());
		foreach(var obj in jObject["levels"]["level"][Level]["implement"]["enemy"].list)
			CreateMoscon(obj[0].ToString().Replace("\"",""),obj[1].ToString().Replace("\"",""), obj[2].ToString().Replace("\"",""));
		FindObjectOfType<GameController> ().NumberOfMoscones = moscones.Count;
		FindObjectOfType<GameController>().SetHour(jObject["levels"]["level"][Level]["implement"]["-hour"].str);

	}

	void Update () {
		timer += Time.deltaTime;
		if(moscones.Count > 0)
		{
			if(moscones[0].GetTimer() < timer)
			{
				moscones[0].gameObject.SetActive(true);
				moscones[0].Launch();
				moscones.RemoveAt(0);
			}
		}
	}

	private void CreateMoscon(string sprite, string time, string street)
	{
		GameObject moscon = (GameObject)Instantiate(mosconesObj[sprite]);
		Vector3 position = Camera.main.ViewportToWorldPoint( new Vector3(1f, (0.37f + (0.17f)*int.Parse(street)), 1f));
		moscon.transform.position = position;
		moscon.GetComponent<MosconAbstract>().SetTimer(int.Parse(time));
		moscones.Add(moscon.GetComponent<MosconAbstract>());
		moscon.gameObject.SetActive (false);
	}
}

