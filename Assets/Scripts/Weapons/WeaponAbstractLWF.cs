using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WeaponAbstractLWF : LWFObject {

	public string[] Images;

	void Start()
	{
		string dir = System.IO.Path.GetDirectoryName(Images[0]);
		if (dir.Length > 0)
			dir += "/";
		
		if (Application.isEditor)
			UseDrawMeshRenderer();


		Load(Images[0], dir);
		Scale (0.30f,0.30f);
	}

	public void SetSprite(int index)
	{
		string dir = System.IO.Path.GetDirectoryName(Images[index]);
		if (dir.Length > 0)
			dir += "/";
		if (Application.isEditor)
			UseDrawMeshRenderer();

		Load(Images[index], dir);
		Scale (0.30f,0.30f);

	}
}
