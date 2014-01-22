using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TorrenteLWF : LWFObject{

	// Use this for initialization
	void Start () {
        string dir = System.IO.Path.GetDirectoryName(lwfName);
        if (dir.Length > 0)
            dir += "/";

        if (Application.isEditor)
            UseDrawMeshRenderer();
		Scale(0.35f,0.35f);
        Load(lwfName, dir);
	}
	
	
}
