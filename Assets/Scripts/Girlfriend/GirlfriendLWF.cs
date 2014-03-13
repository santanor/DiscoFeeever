using UnityEngine;
using System.Collections;
using System.Linq;

public class GirlfriendLWF :MonoBehaviour{

	public GameObject Couple {get; set;}

    void Start()
    {
		Couple = Instantiate (Resources.Load ("/Prefabs/Couples/couple")) as GameObject;
		Couple.GetComponentsInChildren<ShowCouple> ().ToList ().ForEach ((x)=>x.Scale(0.3f,0.3f));
    }

}
