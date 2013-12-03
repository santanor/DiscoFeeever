using UnityEngine;
using System.Collections;

public class Garrulo : MonoBehaviour, Moscon{

	int timer;
	
	public void SetTimer(int timer)
	{
		this.timer = timer;
	}
	
	public int GetTimer()
	{
		return timer;
	}
	public object Clone()
	{
		return this.MemberwiseClone();
	}

	
	void Start()
	{
	}
	
	void Update()
	{
	}
	
	
	public void Launch()
	{
		this.gameObject.rigidbody2D.velocity = Vector3.left;  
	}
}
