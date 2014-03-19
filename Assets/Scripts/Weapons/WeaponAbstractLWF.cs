using UnityEngine;
using System.Collections;
using System;
using LWF;


public abstract class WeaponAbstractLWF : LWFObject {

	public string[] Images;
	private Action<Movie, Button> _callback;

	void Start()
	{
		string dir = System.IO.Path.GetDirectoryName(Images[0]);
		if (dir.Length > 0)
			dir += "/";
		
		if (Application.isEditor)
			UseDrawMeshRenderer();


		Load(Images[0], dir);
		Scale (0.7f,0.7f);
	}

	public void SetSprite(int index)
	{
		string dir = System.IO.Path.GetDirectoryName(Images[index]);
		if (dir.Length > 0)
			dir += "/";
		if (Application.isEditor)
			UseDrawMeshRenderer();

		Load(Images[index], dir);
		Scale (0.7f,0.7f);

	}

	public void LoadState(int state, Action<Movie, Button> callback = null)
	{
		this._callback = callback;
		string dir = System.IO.Path.GetDirectoryName(Images[state]);
		if (dir.Length > 0)
			dir += "/";
		Load(Images[state], dir, lwfLoadCallback:State_Callback);
		Scale(0.7f,0.7f);

	}

	void State_Callback(LWFObject lwfobject)
	{
		// Add callback for fscommand("event", "end_of_frame")  
		lwfobject.AddEventHandler("end_of_frame",_callback );
	}

	public void Enlarge()
	{
		this.Scale(1.1f,1.1f);
	}

	public void Dwarf()
	{
		this.Scale(0.9f, 0.9f);
	}

	abstract public void LoadOnHitMosconState(MosconAbstractLWF moscon);
}
