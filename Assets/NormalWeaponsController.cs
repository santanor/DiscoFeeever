using UnityEngine;
using System.Collections;

public class NormalWeaponsController : MonoBehaviour {

    private Object[] normalWeapons;
    private Vector3[] normalWeaponsPosition;
    private Object currentNormalWeapons;
	// Use this for initialization
	void Start () {
        normalWeapons = Resources.LoadAll<GameObject>("Prefabs/Weapons/Normal weapons");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
