using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Girlfriend : LWFObject {

    void Start()
    {
        string dir = System.IO.Path.GetDirectoryName(lwfName);
        if (dir.Length > 0)
            dir += "/";

        if (Application.isEditor)
            UseDrawMeshRenderer();

        Load(lwfName, dir);
        Scale(0.5f, 0.5f);
    }

}
