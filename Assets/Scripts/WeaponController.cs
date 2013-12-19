using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private int cellWidth;
	private int cellHeight;
	private Weapon weaponTouched;
	private bool selected;

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
				case TouchPhase.Began:
				ManagePhaseBegan(touch);
				break;
			}
		}
	}

	private void ManagePhaseBegan(Touch touch)
	{
		var ray = Camera.main.ScreenPointToRay(touch.position);
		RaycastHit2D hit;
		hit = Physics2D.Raycast (ray.origin, -Vector2.up, 1);
		if (hit.collider != null && hit.collider.gameObject.tag == "Weapon")
			weaponTouched = hit.collider.gameObject.GetComponent<Weapon> ();
						

	}
}
