using UnityEngine;
using System.Collections;
using Puppycode.ScreenUtility;

public class GridController : MonoBehaviour {

    GameObject[,] enemies;
	// Use this for initialization
	void Start () {
        enemies = new GameObject[5, 8];
        GameObject go = (GameObject)Resources.Load("test");
        for(int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
               GameObject g =  (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * j, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * i, +3)), Quaternion.identity);
               g.GetComponent<Tile>().info = i + "," + j;
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended)
            {
                ;
            }
        }
	}
}
