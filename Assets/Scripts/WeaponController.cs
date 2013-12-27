using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private int cellWidth;
	private int cellHeight;
	private Weapon weaponTouched;
	private bool selected;

	// Use this for initialization
	void Start () 
	{
		cellWidth = (int)(Screen.width * 0.0625f);
		cellHeight = (int)(Screen.height * 0.2f);
		selected = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.touchCount == 1)
			if(Input.GetTouch(0).phase == TouchPhase.Ended)
				ManagePhaseEnd(Input.GetTouch(0));
	}

	private void ManagePhaseEnd(Touch touch)
	{
		if(!selected)
		{
			var ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit2D hit;
			hit = Physics2D.Raycast (ray.origin, -Vector2.up, 1);
			if (hit.collider != null && hit.collider.gameObject.tag == "Weapon")
			{
				weaponTouched = hit.collider.gameObject.GetComponent<Weapon> ();
				selected = true;
			}
		}
		else if(selected)
		{
			selected = false;
			weaponTouched.DropWeapon(touch.position, cellWidth, cellHeight);

		}
	}
}
