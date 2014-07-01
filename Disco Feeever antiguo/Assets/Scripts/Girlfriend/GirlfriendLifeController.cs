using UnityEngine;
using System.Collections;

public class GirlfriendLifeController : MonoBehaviour {

	public Girlfriend girlfriend;
	float life;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		life = girlfriend.Life/100;
		Color c = new Color(1f,1f,1f,life);
		this.renderer.material.color = c;	
	}
}
