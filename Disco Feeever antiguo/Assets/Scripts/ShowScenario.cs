using UnityEngine;
using System.Collections;
using LWF;
using System;

public class ShowScenario : LWFObject {

	// Use this for initialization
	void Start () {
		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		Scale (0.5f, 0.5f);
		Load(lwfName, dir);
	}
}
