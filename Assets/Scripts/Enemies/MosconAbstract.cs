using UnityEngine;
using System;

public abstract class MosconAbstract : MonoBehaviour
{

	public int MinVelocity {get; set;}
	public int MaxVelocity {get; set;}
	public int Velocity {get; set;}
	public float Life {get; set;}
	public int Timer {get; set;}
	private ScoreController scoreController;
	Girlfriend girlfriend;
	bool dying;


	void Update()
	{
		if(this.Life <= 0 && !dying)
		{
			this.dying = true;
			this.GetComponent<MosconAbstractLWF>().LoadState(3,() => {
				FindObjectOfType<GameController>().NumberOfMoscones--;
				FindObjectOfType<ScoreController>().Score += 50;
				Destroy(this.gameObject);
				return 0;
			});
		}
	}


	public void SetVelocity(int minVelocity, int maxVelocity)
	{
		this.MinVelocity = minVelocity;
		this.MaxVelocity = maxVelocity;
	}

	public int GetVelocity()
	{
		this.Velocity = UnityEngine.Random.Range(MinVelocity, MaxVelocity);
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
		this.StartMoscon ();
		this.gameObject.rigidbody2D.velocity = Vector3.left*GetVelocity();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Limit")
		{
			this.rigidbody2D.velocity = Vector3.zero;
			girlfriend = GameObject.Find("Girlfriend").GetComponent<Girlfriend>();
			this.GetComponent<MosconAbstractLWF>().LoadState(2, ()=>2);
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Limit")
			this.girlfriend.Life -= 1*Time.deltaTime;
	}

	abstract public void StartMoscon();
}


