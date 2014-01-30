using UnityEngine;
using System.Collections;

public class Torrente : MosconAbstract 
{
	void Start()
	{
		base.SetVelocity(10,20);
		base.Life = 90;
	}
}
