using UnityEngine;
using System.Collections;

public class Garrulo : MosconAbstract
{
	void Start()
	{
		base.SetVelocity(20,30);
		base.Life = 120;
	}
}
