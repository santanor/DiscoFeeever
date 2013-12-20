using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
		
	public Rigidbody2D rigidbody;


	public void FollowTouch(Vector3 position)
	{
		Vector3 vector = new Vector3(position.x,position.y,1);
		this.gameObject.transform.position = vector;
	}

	public void DropWeapon(Vector3 position,int cellWidth, int cellHeight)
	{
		int cellX = (int)(position.x/cellWidth);
		int cellY = (int)(position.y/cellHeight) -1;
		float positionX = cellWidth/2 + cellX*cellWidth;
		float positionY = cellHeight/2 + cellY*cellHeight;
		Vector3 cellPosition = new Vector3(positionX,positionY,1);
		this.transform.position = cellPosition;
	}
}
