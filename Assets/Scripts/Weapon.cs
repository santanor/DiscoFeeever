using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
		
	public Rigidbody2D rigidbody;

	void Start()
	{
		print (Camera.main.WorldToScreenPoint( this.transform.position));
	}

	public void FollowTouch(Vector3 position)
	{
		this.gameObject.transform.position = position;

	}

	public void DropWeapon(Vector3 position,int cellWidth, int cellHeight)
	{
		int cellX = (int)(this.transform.position.x/cellWidth);
		int cellY = (int)(this.transform.position.y/cellHeight);
		float positionX = cellWidth/2 + cellX*cellWidth;
		float positionY = cellWidth/2 + cellY*cellHeight;
		Vector3 cellPosition = new Vector3(positionX,positionY,0f);
		this.transform.position = cellPosition;
	}
}
