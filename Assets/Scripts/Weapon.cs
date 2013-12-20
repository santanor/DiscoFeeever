using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
		
	public Rigidbody2D rigidbody;

	void Start()
	{
		DropWeapon (new Vector3 (654, 356, 1), 50, 96);
	}

	public void FollowTouch(Vector3 position)
	{
		Vector3 vector = new Vector3(position.x,position.y,1);
		this.gameObject.transform.position = vector;
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
		print (positionX);
		print (positionY);
		print (cellPosition);
	}

}
