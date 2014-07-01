using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadAudio : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}
	

}
