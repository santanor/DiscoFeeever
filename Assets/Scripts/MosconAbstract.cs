using UnityEngine;

public abstract class MosconAbstract : MonoBehaviour
{

	public int MinVelocity {get; set;}
	public int MaxVelocity {get; set;}
	public int Life {get; set;}
	public int Timer {get; set;}

	public void SetVelocity(int minVelocity, int maxVelocity)
	{
		this.MinVelocity = minVelocity;
		this.MaxVelocity = maxVelocity;
	}

	public int GetVelocity()
	{
		return Random.Range(MinVelocity, MaxVelocity);
	}

	public void SetTimer(int timer)
	{
		this.Timer = timer;
	}

	public int GetTimer()
	{
		return this.Timer;
	}

	public void Launch()
	{
		this.gameObject.rigidbody2D.velocity = Vector3.left*GetVelocity();
	}
}


