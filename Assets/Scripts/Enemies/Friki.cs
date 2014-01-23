using UnityEngine;
using System.Collections;

public class Friki :  MosconAbstract 
{

	void Start()
	{
		base.SetVelocity(10,20);
		base.Life = 70;
	}
}
