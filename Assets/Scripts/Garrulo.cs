using UnityEngine;
using System.Collections;

public class Garrulo : MosconAbstract
{
	void Start()
	{
		base.SetVelocity(30,40);
		base.Life = 120;
	}
}
