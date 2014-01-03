using UnityEngine;
using System.Collections;

public class Torrente : MosconAbstract 
{
	void Start()
	{
		base.SetVelocity(40,50);
		base.Life = 90;
	}
}
