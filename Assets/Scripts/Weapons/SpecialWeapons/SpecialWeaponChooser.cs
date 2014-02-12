using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpecialWeaponChooser : MonoBehaviour {

	Object[] specialWeapons;
	public bool[] specialWeaponsUsed;
	Vector3[] positionSpecialWeapons;
	GameObject[] currentSpecialWeapons;
	float timeToReload;

	// Use this for initialization
	void Start () 
	{
		float offset;
		//PlayerPrefs.SetString("SpecialWeapons","0");
		string a = PlayerPrefs.GetString("SpecialWeapons","");
		timeToReload = 5f;
		IList<Object> sWeapons = new List<Object>();
		specialWeaponsUsed = new bool[2];
		currentSpecialWeapons = new GameObject[2];
		positionSpecialWeapons = new Vector3[2];
		foreach(string weapon in PlayerPrefs.GetString("SpecialWeapons","").Split(',')) //El formato es algo como (2,1,5,3)
			sWeapons.Add(Resources.Load("Prefabs/SpecialWeapons/"+weapon));
		specialWeapons = sWeapons.ToArray();

		for(int i = 0; i < 2; i++)
		{
			GameObject weapon = ChooseWeapon();
			offset = i*0.1f;
			positionSpecialWeapons[i] = Camera.main.ViewportToWorldPoint(new Vector3(0.8f+offset,0.14f,80));
			weapon.transform.position = positionSpecialWeapons[i];
			weapon.GetComponent<WeaponAbstract>().Position = i;
			weapon.GetComponent<WeaponAbstract>().PositionVector = positionSpecialWeapons[i];
			weapon.GetComponent<WeaponAbstract>().special = true;
			specialWeaponsUsed[i] = true;
			currentSpecialWeapons[i] = weapon;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < specialWeaponsUsed.Length; i++)
		{
			if(!specialWeaponsUsed[i])
			{
				currentSpecialWeapons[i] = null;
				StartCoroutine(ReloadWeapon(i));
				specialWeaponsUsed[i] = true;
			}
		}
	}

	IEnumerator ReloadWeapon(int i )
	{
		specialWeaponsUsed[i] = true;
		float reload = timeToReload;
		while(reload > 0)
		{
			reload -= Time.deltaTime;
			yield return null;
		}
		currentSpecialWeapons[i] = ChooseWeapon();
		currentSpecialWeapons[i].GetComponent<WeaponAbstract>().special = true;
		currentSpecialWeapons[i].transform.position = positionSpecialWeapons[i];
	}

	GameObject ChooseWeapon()
	{
		return Instantiate(specialWeapons[Random.Range(0, specialWeapons.Length)]) as GameObject;
	}
}
