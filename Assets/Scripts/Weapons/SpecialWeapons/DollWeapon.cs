using UnityEngine;
using System.Collections;

public class DollWeapon : WeaponAbstract {

	private float life;

	// Use this for initialization
	void Start () {
		normalWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<NormalWeaponChooser>();
		specialWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<SpecialWeaponChooser>();
		this.special = true;
		life = 20;
		FloorDuration = int.MaxValue;
	}

	void Update()
	{
		if(life <= 0)
			Destroy(this.gameObject);
	}
	
	public override void ExecuteDropedEnter(GameObject gObject)
	{
		gObject.rigidbody2D.velocity = Vector3.zero;
		gObject.GetComponent<MosconAbstractLWF>().LoadState(2);
		StartCoroutine(TakeLife(gObject));
	}

	public override void ExecuteDropedStay(GameObject gObject)
	{
	}

	IEnumerator TakeLife(GameObject gObject)
	{
		while(this.life >= 0)
		{
			this.life -= 1*Time.deltaTime;
			yield return null;
		}
		gObject.rigidbody2D.velocity = Vector3.left * gObject.GetComponent<MosconAbstract>().GetVelocity();
		gObject.GetComponent<MosconAbstractLWF>().LoadState(0);
	}

	public override void ExecuteDropedExit(GameObject gObject)
	{
	}

	public override void ExecuteAir(GameObject gObject)
	{
		this.ExecuteDropedEnter(gObject);
	} 
}
