using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private float cellWidth;
	private float cellHeight;
	private WeaponAbstract weaponTouched;
	private bool selected;
	public GridController gridController;

	// Use this for initialization
	void Start () 
	{
		cellWidth = ScreenExt.Width(10f);
		cellHeight = ScreenExt.Height(16.666f);
		selected = false;
        int a = Application.levelCount;
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
		var ray = Camera.main.ScreenPointToRay(touch.position);;
		RaycastHit2D hit;
		if(!selected)
		{
			hit = Physics2D.Raycast (ray.origin, -Vector2.up, 1);
			if (hit.collider != null && hit.collider.gameObject.tag == "Weapon")
			{
				weaponTouched = hit.collider.gameObject.GetComponent<WeaponAbstract> ();
				gridController.EnableSprite();
				weaponTouched.GetComponent<WeaponAbstractLWF>().Enlarge();
				selected = true;
			}
		}
		else if(selected)
		{
			float a = ScreenExt.Width(16.666666666f);
			float b = ScreenExt.Height(16.666666666f);
			float c = ScreenExt.Height(85);
			weaponTouched.GetComponent<WeaponAbstractLWF>().Dwarf();
			if(touch.position.x > a && (touch.position.y > b && touch.position.y < c))
			{
				selected = false;
				float posCellX = (((int)((touch.position.x - a)/cellWidth)) * cellWidth)+a + cellWidth/2- weaponTouched.gameObject.GetComponent<LWFObject>().lwf.width;
				float posCellY = (((int)((touch.position.y - b)/cellHeight)) * cellHeight)+b + weaponTouched.gameObject.GetComponent<LWFObject>().lwf.height;
				gridController.DisableSprite();
				weaponTouched.DropWeapon(touch.position, posCellX, posCellY);
			}
			else if (touch.position.x > a && (touch.position.y < b))
			{
				selected = false;
				gridController.DisableSprite();
				hit = Physics2D.Raycast (ray.origin, -Vector2.up, 1);
				if (hit.collider != null && hit.collider.gameObject.tag == "Weapon" && (hit.collider.gameObject != weaponTouched)//Para saber si se deben juntar las armas
				    &&(hit.collider.gameObject.GetComponent<WeaponAbstract>().Level +weaponTouched.Level )<=3
				    && hit.collider.gameObject.GetComponent<WeaponAbstract>().Color == weaponTouched.Color)
				{
					hit.collider.gameObject.GetComponent<WeaponAbstract>().Level += weaponTouched.Level;
					hit.collider.gameObject.GetComponent<WeaponAbstract>().RecalculateWeaponStats();
					GameObject.Find("Weapon Controller").GetComponent<NormalWeaponChooser>().normalWeaponsUsed[weaponTouched.Position] = false;
					DestroyImmediate(weaponTouched.gameObject);
					hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().SetSprite(hit.collider.gameObject.GetComponent<WeaponAbstract>().Level-1);
				}
			}
			else
				selected = false;

		}
	}
}
