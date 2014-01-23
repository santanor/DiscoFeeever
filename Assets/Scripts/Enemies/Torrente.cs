using UnityEngine;
using System.Collections;

public class Torrente : MosconAbstract 
{
	void Start()
	{
		base.SetVelocity(20,30);
		base.Life = 90;
	}
}
