﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Chulo :  MosconAbstract
{

	void Start()
	{
		base.SetVelocity(30,40);
		base.Life = 100;
	}
}

