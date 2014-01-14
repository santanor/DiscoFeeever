using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FrikiLWF : LWFObject {

	// Use this for initialization
	void Start () {
		string dir = System.IO.Path.GetDirectoryName(lwfName);
		if (dir.Length > 0)
			dir += "/";
		
		if (Application.isEditor)
			UseDrawMeshRenderer();
		
		Load(lwfName, dir);
		Scale(0.07f, 0.07f);

		
	}
}
