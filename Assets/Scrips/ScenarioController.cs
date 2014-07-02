using UnityEngine;
using System.Collections;
using System.Linq;

/// <summary>
/// Loads the lwf of the scenario depending on the aspect of the Screen
/// </summary>
[ExecuteInEditMode]
public class ScenarioController : LWFObject{

	// Use this for initialization
	void Start () {
        string scenario = "Envs/env_" + PlayerPrefs.GetString("scenario", "01") + "_" + Camera.main.aspect.ToString().Replace(".", "").Substring(0, 2) + ".swf/env_" + PlayerPrefs.GetString("scenario", "01") + "_" + Camera.main.aspect.ToString().Replace(".", "").Substring(0, 2);
        string dir = System.IO.Path.GetDirectoryName(scenario);
		if (dir.Length > 0)
			dir += "/";
		Load(scenario, dir);
        Camera.main.orthographicSize = this.lwf.height / 2;
		this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		this.transform.position = new Vector3(this.transform.position.x - this.lwf.width, this.transform.position.y, 0);
	}
}
