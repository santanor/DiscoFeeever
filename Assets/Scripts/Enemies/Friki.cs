using UnityEngine;
using System.Collections;

public class Friki :  MosconAbstract 
{

	public override void StartMoscon()
	{
		base.SetVelocity(5,10);
		base.Life = 70;
	}
}
