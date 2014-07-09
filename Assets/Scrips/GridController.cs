using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Puppycode.PuppyScreen;

public class GridController : MonoBehaviour {

    GameObject[,] grid;
    public Vector3[,] positions;
    float timePerTurn;
    IList<GameObject> waveEnemies;
	// Use this for initialization
	void Start () {
        waveEnemies = new List<GameObject>();
        positions = new Vector3[5, 9];
        positions[0, 0] = new Vector3(170, -620, -8);
        positions[0, 1] = new Vector3(310, -620, -8);
        positions[0, 2] = new Vector3(440, -620, -8);
        positions[0, 3] = new Vector3(580, -620, -8);
        positions[0, 4] = new Vector3(710, -620, -8);
        positions[0, 5] = new Vector3(850, -620, -8);
        positions[0, 6] = new Vector3(990, -620, -8);
        positions[0, 7] = new Vector3(1125, -620, -8);
        positions[0, 8] = new Vector3(1245, -620, -8);

        positions[1, 0] = new Vector3(170, -510, -7);
        positions[1, 1] = new Vector3(310, -510, -7);
        positions[1, 2] = new Vector3(440, -510, -7);
        positions[1, 3] = new Vector3(580, -510, -7);
        positions[1, 4] = new Vector3(710, -510, -7);
        positions[1, 5] = new Vector3(850, -510, -7);
        positions[1, 6] = new Vector3(990, -510, -7);
        positions[1, 7] = new Vector3(1125, -510, -7);
        positions[1, 8] = new Vector3(1245, -510, -7);

        positions[2, 0] = new Vector3(170, -385, -6);
        positions[2, 1] = new Vector3(310, -385, -6);
        positions[2, 2] = new Vector3(440, -385, -6);
        positions[2, 3] = new Vector3(580, -385, -6);
        positions[2, 4] = new Vector3(710, -385, -6);
        positions[2, 5] = new Vector3(850, -385, -6);
        positions[2, 6] = new Vector3(990, -385, -6);
        positions[2, 7] = new Vector3(1125, -385, -6);
        positions[2, 8] = new Vector3(1245, -385, -6);

        positions[3, 0] = new Vector3(170, -260, -5);
        positions[3, 1] = new Vector3(310, -260, -5);
        positions[3, 2] = new Vector3(440, -260, -5);
        positions[3, 3] = new Vector3(580, -260, -5);
        positions[3, 4] = new Vector3(710, -260, -5);
        positions[3, 5] = new Vector3(850, -260, -5);
        positions[3, 6] = new Vector3(990, -260, -5);
        positions[3, 7] = new Vector3(1125, -260 - 5);
        positions[3, 8] = new Vector3(1245, -260, -5);

        positions[4, 0] = new Vector3(170, -137, -4);
        positions[4, 1] = new Vector3(310, -137, -4);
        positions[4, 2] = new Vector3(440, -137, -4);
        positions[4, 3] = new Vector3(580, -137, -4);
        positions[4, 4] = new Vector3(710, -137, -4);
        positions[4, 5] = new Vector3(850, -137, -4);
        positions[4, 6] = new Vector3(990, -137, -4);
        positions[4, 7] = new Vector3(1125, -137, -4);
        positions[4, 8] = new Vector3(1245, -137, -4);

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
