using UnityEngine;
using System.Collections;

public class SombraLWF : LWFObject {

	// Use this for initialization
	void Start () {
	
		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		Load(lwfName,dir);
	}

}
