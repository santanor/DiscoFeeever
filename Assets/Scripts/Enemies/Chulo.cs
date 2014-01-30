using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Chulo :  MosconAbstract
{

	public override	void StartMoscon()
	{
		base.SetVelocity(10,20);
		base.Life = 100;
	}
}

