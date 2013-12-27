using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	[HideInInspector]
	public int Position{get; set;}
	public WeaponChooser chooser;

	void Start()
	{
		chooser = GameObject.Find("Weapon Controller").GetComponent<WeaponChooser>();
	}

	public void DropWeapon(Vector3 position,int cellWidth, int cellHeight)
	{
		int cellX = (int)(position.x/cellWidth);
		int cellY = (int)(position.y / cellHeight);
		float positionX = (0.0625f/2)+cellX*0.0625f;
		float positionY = (0.2f/2)+ cellY*0.2f;
		Vector3 rayCellPosition = Camera.main.ViewportPointToRay(new Vector3(positionX,positionY,0)).origin;
		Vector3 cellPosition = new Vector3(rayCellPosition.x, rayCellPosition.y,1);
		this.transform.position = cellPosition;
		Invoke("ChangeTag",0.1f);
		chooser.normalWeaponsUsed[this.Position] = false;
	}

	public void ChangeTag()
	{
		this.gameObject.tag = "WeaponDroped";
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.collider.gameObject.tag == "WeaponDroped")
			Destroy (collider.collider.gameObject);
	}
}
