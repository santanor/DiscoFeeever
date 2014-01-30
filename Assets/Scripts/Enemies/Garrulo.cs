using UnityEngine;
using System.Collections;

public class Garrulo : MosconAbstract
{
	void Start()
	{
		base.SetVelocity(7,15);
		base.Life = 120;
	}
}
