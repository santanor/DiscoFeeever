using UnityEngine;
using System.Collections;
using LWF;
using System;
public class MosconAbstractLWF : LWFObject {
	
	public string[] states;
	int callbackState;
	Func<int> _callback;
	// Use this for initialization
	void Start()
	{
		string dir = System.IO.Path.GetDirectoryName(states[0]);
		if (dir.Length > 0)
			dir += "/";
		
		Scale(0.3f,0.3f);
		Load(states[0], dir);
	}
	
	public void LoadState(int state, Func<int> callback =null)
	{
		_callback = callback;
		if(_callback == null) _callback = ()=>0;
		string dir = System.IO.Path.GetDirectoryName(states[state]);
		if (dir.Length > 0)
			dir += "/";
		Scale(0.3f,0.3f);
		Load(states[state],dir,lwfLoadCallback:State_Callback);
	}
	
	void State_Callback(LWFObject lwfobject)
	{
		// Add callback for fscommand("event", "end_of_frame")  
		lwfobject.AddEventHandler("end_of_frame",LoadStateCallback );
	}
	
	void LoadStateCallback(Movie movie, Button button)
	{
		callbackState = _callback();
		if(callbackState >=0)
		{
			string dir = System.IO.Path.GetDirectoryName(states[callbackState]);

			if (dir.Length > 0)
				dir += "/";
			
			Scale(0.3f,0.3f);
			Load(states[callbackState], dir);
		}
	}
}
