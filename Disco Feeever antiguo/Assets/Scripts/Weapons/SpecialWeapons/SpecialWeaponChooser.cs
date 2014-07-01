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
	IDictionary<string, string> _weaponToPlayerPrefs;


	// Use this for initialization
	void Start () 
	{
		timeToReload = 5f;
		specialWeaponsUsed = new bool[2];
		currentSpecialWeapons = new GameObject[2];
		positionSpecialWeapons = new Vector3[2];
		_weaponToPlayerPrefs = new Dictionary<string,string> ();
		specialWeapons = Resources.LoadAll ("Prefabs/SpecialWeapons/");
	}

	public void _Start()
	{
		float offset;
		//Suponiendo las 6 armas especiales del principio
		_weaponToPlayerPrefs.Add (specialWeapons [0].name, "extintorNivel1"); 
		_weaponToPlayerPrefs.Add (specialWeapons [1].name, "muñecaNivel1"); 
		_weaponToPlayerPrefs.Add (specialWeapons [2].name, "chupitoNivel1"); 
		_weaponToPlayerPrefs.Add (specialWeapons [3].name, "extintorNivel2"); 
		_weaponToPlayerPrefs.Add (specialWeapons [4].name, "muñecaNivel2"); 
		_weaponToPlayerPrefs.Add (specialWeapons [5].name, "chupitoNivel2"); 

		for(int i = 0; i < 2; i++)
		{
			GameObject weapon = ChooseWeapon();
			offset = i*0.1f;
			positionSpecialWeapons[i] = Camera.main.ViewportToWorldPoint(new Vector3(0.8f+offset,0.16f,80));
			if(weapon != null)
			{
				weapon.transform.position = positionSpecialWeapons[i];
				weapon.GetComponent<WeaponAbstract>().Position = i;
				weapon.GetComponent<WeaponAbstract>().PositionVector = positionSpecialWeapons[i];
				weapon.GetComponent<WeaponAbstract>().special = true;
				specialWeaponsUsed[i] = true;
				currentSpecialWeapons[i] = weapon;
			}
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
			}
				specialWeaponsUsed[i] = true;
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
		if (currentSpecialWeapons [i] != null) 
		{
			currentSpecialWeapons [i].GetComponent<WeaponAbstract> ().special = true;
			currentSpecialWeapons [i].transform.position = positionSpecialWeapons [i];
		}
	}

	GameObject ChooseWeapon()
	{
		Object[] objs = specialWeapons.Where (item => PlayerPrefs.GetInt(_weaponToPlayerPrefs[item.name]) > 0).ToArray();
		if (objs.Length >= 1) 
		{
			GameObject go = Instantiate (objs [Random.Range (0, objs.Length)]) as GameObject;
			PlayerPrefs.SetInt (_weaponToPlayerPrefs [go.name.Replace ("(Clone)", "")], PlayerPrefs.GetInt (_weaponToPlayerPrefs [go.name.Replace ("(Clone)", "")]) - 1);
			//print(PlayerPrefs.GetInt (_weaponToPlayerPrefs [go.name.Replace ("(Clone)", "")]));
			return go;
		}
		return null;
	}

	public void ReincorporateWeapons()
	{
		for (int i = 0; i < this.specialWeaponsUsed.Length; i++)
		{
			if(currentSpecialWeapons[i] != null)			
				PlayerPrefs.SetInt(_weaponToPlayerPrefs[currentSpecialWeapons[i].name.Replace ("(Clone)", "")], PlayerPrefs.GetInt(_weaponToPlayerPrefs[currentSpecialWeapons[i].name.Replace ("(Clone)", "")])+1);

		}
	}

}