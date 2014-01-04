using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private float cellWidth;
	private float cellHeight;
	private WeaponAbstract weaponTouched;
	private bool selected;

	// Use this for initialization
	void Start () 
	{
		cellWidth = ScreenExtension.GetPercentWidth(10f);
		cellHeight = ScreenExtension.GetPercentHeight(16.666f);
		selected = false;
		print (ScreenExtension.GetPercentWidth(20));
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
				weaponTouched = hit.collider.gameObject.GetComponent<WeaponAbstract> ();
				selected = true;
			}
		}
		else if(selected)
		{
			float a = ScreenExtension.GetPercentWidth(16.666666666f);
			float b = ScreenExtension.GetPercentHeight(16.666666666f);
			float c = ScreenExtension.GetPercentHeight(85);
			if(touch.position.x > a && (touch.position.y > b && touch.position.y < c))
			{
				selected = false;
				float posCellX = (((int)((touch.position.x - a)/cellWidth)) * cellWidth)+a + cellWidth/2;
				float posCellY = (((int)((touch.position.y - b)/cellHeight)) * cellHeight)+b;
				weaponTouched.DropWeapon(touch.position, posCellX, posCellY);
			}
			else
				selected = false;

		}
	}
}
