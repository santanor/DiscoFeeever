using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

/// <summary>
/// Weapon chooser.
/// I was extremly high when I wrote this.
/// </summary>
public class NormalWeaponChooser : MonoBehaviour {

	Object[] normalWeapons;
	Vector3[] positionNormalWeapons;
	GameObject[] currentNormalWeapons;
	float timeToMove;
	float distanceBetweenObjects;
	public bool[] normalWeaponsUsed{get; set;}

	// Use this for initialization
	void Start () 
	{

		normalWeapons = Resources.LoadAll("Prefabs/NormalWeapons");
		normalWeaponsUsed = new bool[3]; 
		positionNormalWeapons = new Vector3[4];
		currentNormalWeapons = new GameObject[4];
	}

	public void _Start()
	{
		float offset;
		timeToMove = 1.5f;
		for(int i = 0; i < 3; i++)
		{
			GameObject weapon = ChooseWeapon();
			offset = i*0.1f;
			positionNormalWeapons[i] = Camera.main.ViewportToWorldPoint(new Vector3(0.3f+offset,0.11f,80));
			weapon.transform.position = positionNormalWeapons[i];
			weapon.GetComponent<WeaponAbstract>().Position = i;
			weapon.GetComponent<WeaponAbstract>().PositionVector = positionNormalWeapons[i];
			normalWeaponsUsed[i] = true;
			currentNormalWeapons[i] = weapon;
		}
		currentNormalWeapons[3] = ChooseWeapon();
		offset = 0.3f;
		positionNormalWeapons[3] = Camera.main.ViewportToWorldPoint(new Vector3(0.6f,0.11f,1f));
		currentNormalWeapons[3].transform.position = positionNormalWeapons[3];
		currentNormalWeapons[3].GetComponent<WeaponAbstract>().PositionVector = positionNormalWeapons[3];
		currentNormalWeapons[3].collider2D.enabled = false;
	}

	void Update()
	{
		for(int i = 0; i < normalWeaponsUsed.Length; i++)
		{
			if(!normalWeaponsUsed[i])
			{
				currentNormalWeapons[i] = null;
				ReordenateWeapons(i);
				normalWeaponsUsed[i] = true;
			}
		}
		for(int j = 0; j < currentNormalWeapons.Length; j++)
		{
		currentNormalWeapons[j].transform.position = Vector3.MoveTowards(currentNormalWeapons[j].transform.position, currentNormalWeapons[j].GetComponent<WeaponAbstract>().PositionVector, timeToMove);
		}
	}

	void ReordenateWeapons(int j)
	{
		for(int i = j; i < currentNormalWeapons.Length-1;i++)
			currentNormalWeapons[i] = currentNormalWeapons[i+1];
		currentNormalWeapons[3] = ChooseWeapon();
		currentNormalWeapons[3].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.7f,-0.2f,1f));
		currentNormalWeapons[3].collider2D.enabled = false;


		for(int i =0; i < this.currentNormalWeapons.Length; i++)
		{
			currentNormalWeapons[i].GetComponent<WeaponAbstract>().Position = i;
			currentNormalWeapons[i].GetComponent<WeaponAbstract>().PositionVector = positionNormalWeapons[i];
			if(i == 2)
				currentNormalWeapons[i].collider2D.enabled = true;

		}
	}


	GameObject ChooseWeapon()
	{
         return Instantiate(normalWeapons[Random.Range(0, normalWeapons.Length)]) as GameObject;
	}
}

