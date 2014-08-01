using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour {

    WeaponAbstractLWF weaponTouched;
    bool selected;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (Input.touchCount == 1)
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
                ManagePhaseEnd(Input.GetTouch(0));
        //print(Camera.main.ScreenToWorldPoint( Input.mousePosition));
    }

    private void ManagePhaseEnd(Touch touch)
    {
        var ray = Camera.main.ScreenPointToRay(touch.position); ;
        RaycastHit2D hit;
        if (!selected)
        {
            hit = Physics2D.Raycast(ray.origin, -Vector2.up, 1);
            if (hit.collider != null && hit.collider.gameObject.tag == "Weapon")
            {
                weaponTouched = hit.collider.gameObject.GetComponent<WeaponAbstractLWF>();
                weaponTouched.GetComponent<WeaponAbstractLWF>().Enlarge();
                selected = true;
            }
        }
        else if (selected)
        {
            if(touch.position.x < Camera.main.WorldToScreenPoint(new Vector3(160,0,0)).x || touch.position.y > Camera.main.WorldToScreenPoint(new Vector3(0,-160,0)).y || touch.position.y > Camera.main.WorldToScreenPoint(new Vector3(0, -760, 0)).y)
            {
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				int y = (int)((touchPosition.x - 165) / 140);
				int x = Mathf.Abs( Mathf.Abs( (int)((touchPosition.y + 165) / 110)) -4);
				weaponTouched.transform.position = FindObjectOfType<GridController>().positions[x,y];
				GameObject.Find("Weapons").GetComponent<NormalWeaponsController>()._normalWeaponsUsed[weaponTouched.Position] = false;
				selected = false;
			}
            else if (touch.position.x > Camera.main.WorldToScreenPoint(new Vector3(160, 0, 0)).x && touch.position.y < Camera.main.WorldToScreenPoint(new Vector3(0, -760, 0)).y)
            {
                hit = Physics2D.Raycast(ray.origin, -Vector2.up, 1);
                if (hit.collider != null && hit.collider.gameObject.tag == "Weapon" && (hit.collider.gameObject != weaponTouched)//Para saber si se deben juntar las armas
                        && (hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().Level + weaponTouched.Level) <= 3
                        && hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().Color == weaponTouched.Color)
                {
                    hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().Level += weaponTouched.Level;
                    hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().RecalculateWeaponStats();
                    GameObject.Find("Weapons").GetComponent<NormalWeaponsController>()._normalWeaponsUsed[weaponTouched.Position] = false;
                    DestroyImmediate(weaponTouched.gameObject);
                    hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().SetSprite(hit.collider.gameObject.GetComponent<WeaponAbstractLWF>().Level - 1);
					selected = false;
                }
            }
			else
			{
				weaponTouched.GetComponent<WeaponAbstractLWF>().Dwarf();
				selected = false;
			}
            
        }
        else
            selected = true;

    }
}
