using UnityEngine;
using System.Collections;

public class Garrulo : MosconAbstract
{
	public override void StartMoscon()
	{
		base.SetVelocity(7,15);
		base.Life = 120;
	}
}
