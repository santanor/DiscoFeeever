using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	void Start()
	{

	}

	// Update is called once per frame
	void Update () {
	
		foreach(var touch in Input.touches)
		{
			if(touch.phase == TouchPhase.Began)
			{
				var ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, -Vector2.up, 1);
				if (hit.collider != null && hit.collider.gameObject.tag == "Play")
					Application.LoadLevel("Levels");
				
			}
		}
	}
}
