using UnityEngine;
using System.Collections;
using LWF;
public class MosconAbstractLWF : LWFObject {

	public string[] states;
	
	// Use this for initialization
	void Start()
	{
		string dir = System.IO.Path.GetDirectoryName(states[0]);
		if (dir.Length > 0)
			dir += "/";
		
		Scale(0.3f,0.3f);
		Load(states[0], dir);
	}
	
	
	public void LoadState(int state)
	{
		string dir = System.IO.Path.GetDirectoryName(states[state]);
		if (dir.Length > 0)
			dir += "/";
		Scale(0.3f,0.3f);
		Load(states[state],dir,lwfLoadCallback:State_Callback);
	}
	
	void State_Callback(LWFObject lwfobject)
	{
		// Add callback for fscommand("event", "end_of_frame")  
		lwfobject.AddEventHandler("end_of_frame",StateEndOfFrameCallback );
	}
	
	void StateEndOfFrameCallback(Movie movie, Button button)
	{
		string dir = System.IO.Path.GetDirectoryName(states[0]);

		if (dir.Length > 0)
			dir += "/";
		
		Scale(0.3f,0.3f);
		Load(states[0], dir);
	}
}
