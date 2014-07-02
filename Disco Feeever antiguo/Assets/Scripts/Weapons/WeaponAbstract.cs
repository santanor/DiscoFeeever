﻿using UnityEngine;
using System.Collections;

public abstract class WeaponAbstract : MonoBehaviour {

	[HideInInspector]
	public int Position {get; set;}
	public Vector3 PositionVector{get; set;}
	public NormalWeaponChooser normalWeaponChooser;
	public SpecialWeaponChooser specialWeaponChooser;
	public bool Droped {get; set;}
	public float Damage {get; set;}
	public int Level {get; set;}
	public float FloorDuration{get; set;}
	public string Color {get; set;}
	public bool special {get; set;}

	void Start()
	{
		this.gameObject.collider2D.enabled = false;
		this.Droped = false;
	}


	public void DropWeapon(Vector3 position,float posCellX, float posCellY)
	{
		this.gameObject.collider2D.enabled = false;
		Vector3 rayCellPosition = Camera.main.ScreenPointToRay (new Vector3 (posCellX, posCellY, 80)).origin;
		Vector3 cellPosition = new Vector3 (rayCellPosition.x, rayCellPosition.y, 1);
		if(this.special)
		{
			specialWeaponChooser.specialWeaponsUsed[this.Position] = false;
			this.GetComponent<WeaponAbstractLWF>().LoadState(1);//Sprite en el suelo

		}
		else
			normalWeaponChooser.normalWeaponsUsed [this.Position] = false;
		StartCoroutine(MoveWeapon(cellPosition));
	}

	void Drop ()
	{
		this.gameObject.collider2D.enabled = true;
		Invoke ("ChangeTag", 0.1f);
		Destroy(this.gameObject, FloorDuration);
	}

	IEnumerator MoveWeapon(Vector3 cellPosition)
	{
		float distance = Vector3.Distance(this.transform.position, cellPosition)/2;
		while(this.transform.position != cellPosition)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, cellPosition, 15f);
			if(Vector3.Distance(this.transform.position, cellPosition) > distance)
				this.GetComponent<WeaponAbstractLWF>().Scale(1.03f,1.03f);
			else
				this.GetComponent<WeaponAbstractLWF>().Scale(0.97f,0.97f);
			yield return null;
		}
		this.Drop();
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
			if(!special)
			{
				GameObject go = Instantiate( Resources.Load("Prefabs/Particle/Hit") )as GameObject;
				go.transform.position = this.transform.position;
				go.particleSystem.Play(true);
			}
			this.GetComponent<WeaponAbstractLWF>().LoadOnHitMosconState(collider.GetComponent<MosconAbstractLWF>());
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
		{
			FindObjectOfType<ScoreController>().Score += 1;
			this.ExecuteDropedStay(collider.gameObject);
		}
	}

	public void RecalculateWeaponStats()
	{
		this.FloorDuration = (this.FloorDuration+this.Level)*1.5f;
		this.Damage = (this.Damage+this.Level)*1.5f;
	}

	abstract public void ExecuteDropedEnter(GameObject gObject);
	abstract public void ExecuteDropedStay(GameObject gObject);
	abstract public void ExecuteDropedExit(GameObject gObject);
	abstract public void ExecuteAir(GameObject gObject);

}