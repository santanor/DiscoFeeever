using UnityEngine;
using System.Collections;

public class CFX_Layer : MonoBehaviour {


	void Start () 
	{
		this.particleSystem.renderer.sortingLayerName = "Foreground";
	}

}
