using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Chulo :  MosconAbstract
{

	public override	void StartMoscon()
	{
		base.SetVelocity(7,10);
		base.Life = 20;
	}
}

