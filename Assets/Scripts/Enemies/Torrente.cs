using UnityEngine;
using System.Collections;

public class Torrente : MosconAbstract 
{
	public override void StartMoscon()
	{
		base.SetVelocity(10,20);
		base.Life = 90;
	}
}
