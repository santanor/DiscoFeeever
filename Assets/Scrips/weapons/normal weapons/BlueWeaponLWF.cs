using UnityEngine;
using System.Collections;

public class BlueWeaponLWF : WeaponAbstractLWF {

    void Start()
    {
        this.Color = "Blue";
    }
    public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
    {}
}
