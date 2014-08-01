using UnityEngine;
using System.Collections;
using LWF;

[ExecuteInEditMode]
public class GarruloLWF : MosconAbstractLWF
{

	public override void _Load()
	{
		Load (states[0], dir);
	}
}
