using UnityEngine;
using System.Collections;
using System.Linq;

/// <summary>
/// Loads the lwf of the scenario depending on the aspect of the Screen
/// </summary>
public class ScenarioController : LWFObject{

	// Use this for initialization
	void Start () {
        string scenario = "Envs/env_" + PlayerPrefs.GetString("scenario", "03") + "_" + Camera.main.aspect.ToString().Replace(".", "").Substring(0, 2) + ".swf/env_" + PlayerPrefs.GetString("scenario", "03") + "_" + Camera.main.aspect.ToString().Replace(".", "").Substring(0, 2);
        string dir = System.IO.Path.GetDirectoryName("Envs/env_03_18.swf/env_03_18");
		if (dir.Length > 0)
			dir += "/";

        if (Application.isEditor)
            UseDrawMeshRenderer();

        Load("Envs/env_03_18.swf/env_03_18", dir);

        
	}
}
