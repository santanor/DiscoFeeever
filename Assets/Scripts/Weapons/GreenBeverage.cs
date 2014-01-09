﻿using UnityEngine;
using System.Collections;

public class GreenBeverage : WeaponAbstract {

	void Start()
	{
		chooser = GameObject.Find("Weapon Controller").GetComponent<WeaponChooser>();
		base.Damage = 70;
	}
	
	
	public override void ExecuteDropedEnter(GameObject gObject)
	{
		gObject.rigidbody2D.velocity = Vector3.left * (int)(gObject.GetComponent<MosconAbstract>().Velocity*0.25);
	}
	
	public override void ExecuteDropedStay(GameObject gObject)
	{
		gObject.GetComponent<MosconAbstract>().Life -= (int)(10*Time.deltaTime);
	}
	
	public override void ExecuteDropedExit(GameObject gObject)
	{
		gObject.rigidbody2D.velocity = Vector3.left * (int)(gObject.GetComponent<MosconAbstract>().Velocity);
	}

	
	public override void ExecuteAir(GameObject gObject)
	{
		gObject.GetComponent<MosconAbstract>().Life -= this.Damage;
		Destroy(this.gameObject);
	}
}