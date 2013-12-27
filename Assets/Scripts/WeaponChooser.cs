using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// Weapon chooser.
/// I was extremly high when I wrote this.
/// </summary>
public class WeaponChooser : MonoBehaviour {

	Object[] normalWeapons;
	int numberOfSpecialWeapons;
	float timeToMove;
	float distanceBetweenObjects;
	public bool[] normalWeaponsUsed{get; set;}
	GameObject nextWeapon;

	// Use this for initialization
	void Start () 
	{
		float offset;
		Vector3 position;
        normalWeapons = Resources.LoadAll("Prefabs");
		normalWeaponsUsed = new bool[3]; 
		timeToMove = 1f;
		for(int i = 0; i < 3; i++)
		{
			GameObject weapon = ChooseWeapon("normal");
			offset = i*0.1f;
			position = Camera.main.ViewportToWorldPoint(new Vector3(0.3f+offset,0.075f,90));
			weapon.transform.position = position;
			weapon.GetComponent<Weapon>().Position = i;
			normalWeaponsUsed[i] = true;
		}
        nextWeapon = ChooseWeapon("normal");
		offset = 0.3f;
		position = Camera.main.ViewportToWorldPoint(new Vector3(0.6f,0.075f,1f));
		nextWeapon.transform.position = position;
		nextWeapon.GetComponent<Weapon>().enabled = false;
		Color color = new Color(1f,1f,1f,0.5f);
		nextWeapon.renderer.material.color = color;
		nextWeapon.collider2D.enabled = false;
	}

	void Update()
	{
		for(int i = 0; i < normalWeaponsUsed.Length; i++)
			if(!normalWeaponsUsed[i])
			{
				normalWeaponsUsed[i] = true;
				nextWeapon.GetComponent<Weapon>().Position = i;
				StartCoroutine("ReloadWeaponRoutine",nextWeapon);				
			}
	}

	IEnumerator ReloadWeaponRoutine(GameObject go)
	{
		Vector3 pos = go.transform.position;
		Vector3 targetPos = Camera.main.ViewportToWorldPoint( new Vector3(0.3f+0.1f*(float)go.GetComponent<Weapon>().Position, 0.075f,1f) );
		while(true)
		{
			if(go.transform.position != targetPos)
			{
				go.transform.position = Vector3.MoveTowards(go.transform.position, targetPos, timeToMove);
				yield return null;
			}
			else
			{
				Color c = new Color(1f,1f,1f,1f);
				go.collider2D.enabled = true;
				go.GetComponent<Weapon>().enabled = true;
				go.renderer.material.color = c;
				GameObject gObject = ChooseWeapon("normal");
				gObject.transform.position = pos;
				gObject.GetComponent<Weapon>().enabled = false;
				gObject.collider2D.enabled = false;
				c = new Color(1f,1f,1f,0.5f);
				gObject.renderer.material.color = c;
				nextWeapon = gObject;
				yield break;
			}
		}
		Destroy(go);
	} 


	GameObject ChooseWeapon(string type)
	{
        if(type == "normal")
         return Instantiate(normalWeapons[Random.Range(0, normalWeapons.Length)]) as GameObject;
        else
         return Instantiate(normalWeapons[Random.Range(0, normalWeapons.Length)]) as GameObject;
	}
}

