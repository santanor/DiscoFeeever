using UnityEngine;
using System.Collections;

public class Torrente : MosconAbstract 
{
	public override void StartMoscon()
	{
		base.SetVelocity(5,10);
		base.Life = 40;
	}
}
