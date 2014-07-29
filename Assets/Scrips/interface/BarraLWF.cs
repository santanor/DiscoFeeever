using UnityEngine;
using System.Collections;
using Puppycode.PuppyScreen;

[ExecuteInEditMode]
public class BarraLWF : LWFObject {

	// Use this for initialization
	void Start () {
        string dir = System.IO.Path.GetDirectoryName(lwfName);
        if (dir.Length > 0)
            dir += "/";
        Load(lwfName, dir);
        Scale(1.2f,1.2f);
        this.transform.position = PuppyScreen.ScreenAsWPoint(30, 0, 0);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + this.lwf.height*1.2f, -5);

	}
}
