using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Puppycode.PuppyScreen;

public class GridController : MonoBehaviour {

    GameObject[,] grid;
    float timePerTurn;
    IList<GameObject> waveEnemies;
	// Use this for initialization
	void Start () {
        waveEnemies = new List<GameObject>();
        timePerTurn = 3f;
        grid = new GameObject[5, 8];
        //for(int i = 0; i < 5; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //       GameObject g =  (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * j, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * i, +3)), Quaternion.identity);
        //       g.GetComponent<Tile>().info = i + "," + j;
        //    }
        //}
        GameObject go = Resources.Load<GameObject>("Prefabs/enemies/0");
        GameObject go1 = (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * 10, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * 2, 0)), Quaternion.identity);
        go1.GetComponent<MosconAbstractLWF>().PositionX = 7;
        go1.GetComponent<MosconAbstractLWF>().PositionY = 0;
        go1.GetComponent<MosconAbstractLWF>().Turn = 1;
        waveEnemies.Add(go1);

        GameObject go2 = (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * 10, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * 2, 0)), Quaternion.identity);
        go2.GetComponent<MosconAbstractLWF>().PositionX = 7;
        go2.GetComponent<MosconAbstractLWF>().PositionY = 2;
        go2.GetComponent<MosconAbstractLWF>().Turn = 3;
        waveEnemies.Add(go2);

        GameObject go3 = (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * 10, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * 2, 0)), Quaternion.identity);
        go3.GetComponent<MosconAbstractLWF>().PositionX = 7;
        go3.GetComponent<MosconAbstractLWF>().PositionY = 3;
        go3.GetComponent<MosconAbstractLWF>().Turn = 3;
        waveEnemies.Add(go3);

        GameObject go4 = (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * 10, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * 2, 0)), Quaternion.identity);
        go4.GetComponent<MosconAbstractLWF>().PositionX = 7;
        go4.GetComponent<MosconAbstractLWF>().PositionY = 4;
        go4.GetComponent<MosconAbstractLWF>().Turn = 5;
        waveEnemies.Add(go4);

        GameObject go5 = (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * 10, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * 2, 0)), Quaternion.identity);
        go5.GetComponent<MosconAbstractLWF>().PositionX = 7;
        go5.GetComponent<MosconAbstractLWF>().PositionY = 1;
        go5.GetComponent<MosconAbstractLWF>().Turn = 7;
        waveEnemies.Add(go5);

        GameObject go6 = (GameObject)Instantiate(go, Camera.main.ScreenToWorldPoint(new Vector3(PuppyScreen.Width(19f) + PuppyScreen.Width(10f) * 10, PuppyScreen.Height(23.5f) + PuppyScreen.Height(14.58f) * 2, 0)), Quaternion.identity);
        go6.GetComponent<MosconAbstractLWF>().PositionX = 7;
        go6.GetComponent<MosconAbstractLWF>().PositionY = 2;
        go6.GetComponent<MosconAbstractLWF>().Turn = 7;
        waveEnemies.Add(go6);

        StartCoroutine(UpdateGrid());
	}


    IEnumerator UpdateGrid()
    {
        yield return new WaitForSeconds(timePerTurn);
        while (true)
        {
            foreach (GameObject go in this.waveEnemies)
            {
                if (go.GetComponent<MosconAbstractLWF>().Turn == 0 && go.GetComponent<MosconAbstractLWF>().PositionX > 0)
                {
                    go.GetComponent<MosconAbstractLWF>().PositionX -= 1;
                    StartCoroutine(go.GetComponent<MosconAbstractLWF>().MoveToPosition());
                }
                else if (go.GetComponent<MosconAbstractLWF>().Turn == 1)
                {
                    go.GetComponent<MosconAbstractLWF>().PositionX = 8;
                    StartCoroutine(go.GetComponent<MosconAbstractLWF>().MoveToPosition());
                    go.GetComponent<MosconAbstractLWF>().Turn--;
                }
                else
                    go.GetComponent<MosconAbstractLWF>().Turn--;
            }
            yield return new WaitForSeconds(timePerTurn);
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
