using UnityEngine;
using System.Collections;

public abstract class WeaponAbstract : MonoBehaviour {

	[HideInInspector]
	public int Position{get; set;}
	public WeaponChooser chooser;
	public bool Droped {get; set;}
	public int Damage {get; set;}

	void Start()
	{
		this.gameObject.collider2D.enabled = false;
		this.Droped = false;
	}



	public void DropWeapon(Vector3 position,float posCellX, float posCellY)
	{
		Drop (position, posCellX, posCellY);
	}

	void Drop (Vector3 position, float posCellX, float  posCellY)
	{
		this.gameObject.collider2D.enabled = true;
		Vector3 rayCellPosition = Camera.main.ScreenPointToRay (new Vector3 (posCellX, posCellY, 80)).origin;
		Vector3 cellPosition = new Vector3 (rayCellPosition.x, rayCellPosition.y, 1);
		this.transform.position = cellPosition;
		Invoke ("ChangeTag", 0.1f);
		chooser.normalWeaponsUsed [this.Position] = false;
	}

	public void ChangeTag()
	{
		this.gameObject.tag = "WeaponDroped";
		this.Droped = true;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Enemy" && !this.Droped)
		{
			this.ExecuteAir(collider.gameObject);
			GameObject go = Instantiate( Resources.Load("Prefabs/Particle/Hit") )as GameObject;
			go.transform.position = this.transform.position;
			go.particleSystem.Play(true);
		}

		else if(collider.gameObject.tag == "WeaponDroped")
			Destroy (collider.gameObject);

		else if(collider.gameObject.tag == "Enemy" && this.Droped)
			this.ExecuteDropedEnter(collider.gameObject);

	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Enemy" && this.Droped)
			this.ExecuteDropedExit(collider.gameObject);
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Enemy" && this.Droped)
			this.ExecuteDropedStay(collider.gameObject);
	}


	abstract public void ExecuteDropedEnter(GameObject gObject);
	abstract public void ExecuteDropedStay(GameObject gObject);
	abstract public void ExecuteDropedExit(GameObject gObject);
	abstract public void ExecuteAir(GameObject gObject);

}
