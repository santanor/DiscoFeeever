using UnityEngine;
using System.Collections;

public class Friki :  MosconAbstract 
{

	void Start()
	{
		base.SetVelocity(5,10);
		base.Life = 70;
	}
}
