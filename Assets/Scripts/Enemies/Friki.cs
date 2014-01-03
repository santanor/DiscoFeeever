using UnityEngine;
using System.Collections;

public class Friki :  MosconAbstract 
{

	void Start()
	{
		base.SetVelocity(20,30);
		base.Life = 70;
	}
}
