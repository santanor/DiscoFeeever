using UnityEngine;
using System.Collections;
using System.Linq;
using LWF;

public class ExtinguisherWeapon : WeaponAbstract {

	private float explosionRadius;
	private GameObject objectCollisioned;
	// Use this for initialization
	void Start () {
		normalWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<NormalWeaponChooser>();
		specialWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<SpecialWeaponChooser>();
		this.special = true;
		explosionRadius = 50;
		base.Damage = 100;
		FloorDuration = int.MaxValue;
	}


	public override void ExecuteDropedEnter(GameObject gObject)
	{
		this.gameObject.collider2D.enabled = false;
		this.GetComponent<WeaponAbstractLWF>().LoadState(1, callback:Callback);
	}
	
	public override void ExecuteDropedStay(GameObject gObject){}

	
	public override void ExecuteDropedExit(GameObject gObject){}

	
	public override void ExecuteAir(GameObject gObject)
	{
		this.gameObject.collider2D.enabled = false;
		this.GetComponent<WeaponAbstractLWF>().LoadState(1, callback:Callback);
	}

	public void Callback(Movie movie, Button button)
	{
		foreach(MosconAbstract go in FindObjectsOfType<MosconAbstract>().Where(x => x.gameObject.activeSelf == true).Where(x => Vector3.Distance(x.transform.position, this.gameObject.transform.position) < explosionRadius))
			go.Life -= Damage;
		Destroy(this.gameObject);
	}
}
