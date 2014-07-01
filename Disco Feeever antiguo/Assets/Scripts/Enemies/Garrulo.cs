using UnityEngine;
using System.Collections;

public class Garrulo : MosconAbstract
{
	public override void StartMoscon()
	{
		base.SetVelocity(4,7);
		base.Life = 60;
	}
}
