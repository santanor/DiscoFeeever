using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BlueWeaponLWF : WeaponAbstractLWF {


    public override void _Start()
    {
        base.Color = "Blue";
    }
    public override void LoadOnHitMosconState(MosconAbstractLWF moscon)
    {}
}
