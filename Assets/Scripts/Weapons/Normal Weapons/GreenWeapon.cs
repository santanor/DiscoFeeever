using UnityEngine;
using System.Collections;

public class GreenWeapon : WeaponAbstract {

	// Use this for initialization
	void Start () {
		normalWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<NormalWeaponChooser>();
		specialWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<SpecialWeaponChooser>();
		base.Damage = 3;
		base.Color = "Green";
		base.Level = 1;
		base.FloorDuration = 7f;

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
