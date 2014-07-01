using UnityEngine;
using System.Collections;
using System.Linq;

public class GirlfriendLWF :MonoBehaviour{

	public GameObject Couple {get; set;}
	Vector3 _girlfriendPosition;
    void Start()
    {
		_girlfriendPosition = Camera.main.ViewportToWorldPoint (new Vector3 (0.05f, 0.65f));
		Couple = new GameObject("couple");
		GameObject _head = Instantiate (Resources.Load ("Prefabs/couples/Girl/Heads/" + PlayerPrefs.GetString ("currentHead").Replace ("(Clone)", "")),Camera.main.ViewportToWorldPoint (new Vector3 (0.43f, 0.88f)),Quaternion.identity) as GameObject;
		GameObject _body = Instantiate (Resources.Load ("Prefabs/couples/Girl/Bodies/" + PlayerPrefs.GetString ("currentBody").Replace ("(Clone)", "")), Camera.main.ViewportToWorldPoint (new Vector3 (0.4f, 0.7f,+1)),Quaternion.identity) as GameObject;
		_head.transform.parent = Couple.transform;
		_body.transform.parent = Couple.transform;
		Couple.transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.1f, 0.5f,+1));
		Couple.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
	}

}
