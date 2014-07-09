using UnityEngine;
using System.Collections;

public class PurpleWeaponLWF : WeaponAbstractLWF {

    void Start()
    {
        this.Color = "Purple";
    }
    public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
    { }
}
