using UnityEngine;
using System.Collections;
using System.Linq;
using LWF;

public class StrogWeapon : WeaponAbstract {

	void Start () {
		normalWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<NormalWeaponChooser>();
		specialWeaponChooser = GameObject.Find("Weapon Controller").GetComponent<SpecialWeaponChooser>();
		this.special = true;
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
		foreach(MosconAbstract go in FindObjectsOfType<MosconAbstract>().Where(x => 
								      x.gameObject.activeSelf == true).Where(x => 
								      Vector3.Distance(x.transform.position, new Vector3(x.transform.position.x,this.gameObject.transform.position.y,x.transform.position.z) ) < 20))
		
			go.Life -= Damage;
		Destroy(this.gameObject);
	}
}
