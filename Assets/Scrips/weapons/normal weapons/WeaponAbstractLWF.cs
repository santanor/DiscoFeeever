using UnityEngine;
using System.Collections;
using System;
using LWF;


[ExecuteInEditMode]
public abstract class WeaponAbstractLWF : LWFObject {

	public string[] Images;
    private Action<Movie, Button> _callback;
    public int Position { get; set; }
    public Vector3 PositionVector { get; set; }
    public int Level { get; set; }
    public string Color { get; set; }
    public float Damage { get; set; }
    public int FloorDuration { get; set; }
    public float _width;

	void Start()
	{
		string dir = System.IO.Path.GetDirectoryName(Images[0]);
		if (dir.Length > 0)
			dir += "/";
		
		if (Application.isEditor)
			UseDrawMeshRenderer();


		Load(Images[0], dir);
        this.Level = 1;
        this.FloorDuration = 0;
        _width = this.lwf.width;
        _Start();
	}

	public void SetSprite(int index)
	{
		string dir = System.IO.Path.GetDirectoryName(Images[index]);
		if (dir.Length > 0)
			dir += "/";
		if (Application.isEditor)
			UseDrawMeshRenderer();

		Load(Images[index], dir);
	}

	public void LoadState(int state, Action<Movie, Button> callback = null)
	{
		this._callback = callback;
		string dir = System.IO.Path.GetDirectoryName(Images[state]);
		if (dir.Length > 0)
			dir += "/";
		Load(Images[state], dir, lwfLoadCallback:State_Callback);
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


    public void RecalculateWeaponStats()
    {
        this.FloorDuration = (this.FloorDuration + this.Level);
        this.Damage = (this.Damage + this.Level) * 1.5f;
    }

	abstract public void LoadOnHitMosconState(MosconAbstractLWF moscon);
    abstract public void _Start();
}
