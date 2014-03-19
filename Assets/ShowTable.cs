using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShowTable : LWFObject {

	// Use this for initialization
	void Start () {
		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		
		Scale(0.022f,0.025f);
		Load(lwfName, dir);
	}
}
