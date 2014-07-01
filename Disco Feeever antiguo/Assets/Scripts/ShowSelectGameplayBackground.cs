using UnityEngine;
using LWF;
using System.Collections;

public class ShowSelectGameplayBackground : LWFObject {

	// Use this for initialization
	void Start () {
		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		
		Scale(0.9f,0.9f);
		Load(lwfName, dir);
		this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
	}
	

}
