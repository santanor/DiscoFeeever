using UnityEngine;

public abstract class MosconAbstract : MonoBehaviour
{

	public int MinVelocity {get; set;}
	public int MaxVelocity {get; set;}
	public int Velocity {get; set;}
	public int Life {get; set;}
	public int Timer {get; set;}

	void Update()
	{
		if(this.Life <= 0)
			Destroy(this.gameObject);
	}

	public void SetVelocity(int minVelocity, int maxVelocity)
	{
		this.MinVelocity = minVelocity;
		this.MaxVelocity = maxVelocity;
	}

	public int GetVelocity()
	{
		this.Velocity = Random.Range(MinVelocity, MaxVelocity);
		return Velocity;
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

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Limit")
			this.rigidbody2D.velocity = Vector3.zero;
	}
}


