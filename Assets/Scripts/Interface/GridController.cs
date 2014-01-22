using UnityEngine;
using System.Collections;

public class GridController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().enabled = false;
	}

	public void EnableSprite()
	{
		this.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void DisableSprite()
	{
		this.GetComponent<SpriteRenderer>().enabled = false;
	}
}
