using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private int cellWidth;
	private int cellHeight;

	// Use this for initialization
	void Start () {
		cellWidth = (int)(Screen.width * 0.0625f);
		cellHeight = (int)(Screen.height * 0.2f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Touch touch in Input.touches)
		{
			switch (touch.phase)
			{				
				case TouchPhase.Moved:
				ManagePhaseMoved(touch);
				break;
				
				case TouchPhase.Ended:
				ManagePhaseEnd(touch);
				break;
			}
		}
	}

	private void ManagePhaseMoved(Touch touch)
	{
		var ray = Camera.main.ScreenPointToRay(touch.position);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up);
		if(hit != null)
		{
			if(hit.collider.gameObject.tag == "Weapon")
			{
				var ray2 = Camera.main.ScreenPointToRay(touch.position);
				 hit.collider.gameObject.GetComponent<Weapon>().FollowTouch(ray2.origin);
			}
		}
	}

	private void ManagePhaseEnd(Touch touch)
	{
		var ray = Camera.main.ScreenPointToRay(touch.position);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, -Vector2.up);
		if(hit != null)
		{
			if(hit.collider.gameObject.tag == "Weapon")
			{
				var ray2 = Camera.main.ScreenPointToRay(touch.position);
				hit.collider.gameObject.GetComponent<Weapon>().DropWeapon(ray2.origin, cellWidth, cellHeight);
			}
		}
	}
}
