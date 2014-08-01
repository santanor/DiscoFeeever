using UnityEngine;
using System.Collections;
using LWF;

[ExecuteInEditMode]
public class MazaoLWF : MosconAbstractLWF 
{

	public override void _Load()
	{
		if(this.tag.Equals("Camisa"))
			Load (states[0], dir, ColorRampsTexture: Resources.Load<Texture>("ColorRamps/Blue"));
		else
			Load (states[0], dir);
	}
}
