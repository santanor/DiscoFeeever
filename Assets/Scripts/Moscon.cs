using UnityEngine;
using System.Collections;
using System;

public interface Moscon : ICloneable{
	
	void SetTimer(int timer);
	int GetTimer();
	void Launch();
}
