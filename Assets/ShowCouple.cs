using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShowCouple : LWFObject {

	// Use this for initialization
	void Start () {
		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		Scale (0.7f, 0.7f);
		Load(lwfName, dir);
	}
	
}
